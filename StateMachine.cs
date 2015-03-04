/************************************************
 *
 * file  : StateMachine.cs
 * author: bobding
 * date  : 2015-01-20
 * detail: ״̬������
 *
************************************************/

using System.Collections.Generic;

namespace WeFly
{
    public class StateMachine
    {
        /// <summary>
        /// ״̬�б�
        /// </summary>
        protected Dictionary<uint, State> mStates = new Dictionary<uint, State>();

        /// <summary>
        /// ��ǰ״̬
        /// </summary>
        protected State mCurrentState;

        public State CurrentState
        {
            get { return mCurrentState; }
        }

        /// <summary>
        /// �ж�״̬
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool IsState(uint type)
        {
            if (null != mCurrentState)
            {
                return mCurrentState.StateType == type;
            }

            return false;
        }

        /// <summary>
        /// ��ȡ״̬
        /// </summary>
        /// <param name="type">״̬����</param>
        /// <returns></returns>
        public State GetState(uint type)
        {
            State state;
            if (mStates.TryGetValue(type, out state))
            {
                return state;
            }

            return null;
        }

        /// <summary>
        /// ��ʼ��
        /// </summary>
        /// <returns></returns>
        public virtual bool Initialize()
        {
//             foreach (State state in mStates.Values)
//             {
//                 state.Initialize();
//             }

            return true;
        }

        /// <summary>
        /// ����ʼ��
        /// </summary>
        /// <returns></returns>
        public virtual bool UnInitialize()
        {
            foreach (State state in mStates.Values)
            {
                state.UnInitialize();
            }

            mStates.Clear();

            return true;
        }

        /// <summary>
        /// ����״̬
        /// </summary>
        /// <param name="delat"></param>
        public virtual void Update(float delta)
        {
            if (null != mCurrentState)
            {
                mCurrentState.Update(delta);
            }
        }

        /// <summary>
        /// �л�״̬������״̬���룬���¾�״̬��ͬʱ����ִ��״̬�л�
        /// </summary>
        /// <param name="type"></param>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        public virtual void RunState(uint type, object arg0, object arg1)
        {
            if (null != mCurrentState)
            {
                mCurrentState.Leave(type, null);
                mCurrentState = null;
            }

            if (mStates.ContainsKey(type))
            {
                mCurrentState = mStates[type];
                mCurrentState.Enter(arg0, arg1);
            }
            else
            {
                LogHelper.LogError("[StateMachine.RunState] failed, invaid state: " + type);
            }
        }

        /// <summary>
        /// ֹͣ��ǰ״̬���л�����״̬
        /// </summary>
        public virtual void StopState()
        {
            if (null != mCurrentState)
            {
                mCurrentState.Leave(null, null);
                mCurrentState = null;
            }
        }

        /// <summary>
        /// ע��״̬
        /// </summary>
        /// <param name="type">״̬����</param>
        /// <param name="state">״̬ʵ��</param>
        /// <returns></returns>
        public bool RegisterState(uint type, State state)
        {
            if (mStates.ContainsKey(type))
            {
                LogHelper.LogError("[StateMachine.RegisterState] failed, state already registered, state: " + type);

                return false;
            }

            mStates.Add(type, state);

            return true;
        }

        /// <summary>
        /// ��ע��״̬
        /// </summary>
        /// <param name="type">״̬����</param>
        /// <returns></returns>
        public bool UnregisterState(uint type)
        {
            if (!mStates.ContainsKey(type))
            {
                LogHelper.LogError("[StateMachine.UnregisterState] failed, state does not exist, state: " + type);

                return false;
            }

            mStates.Remove(type);

            return true;
        }
    }
}