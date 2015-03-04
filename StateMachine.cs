/************************************************
 *
 * file  : StateMachine.cs
 * author: bobding
 * date  : 2015-01-20
 * detail: 状态机基类
 *
************************************************/

using System.Collections.Generic;

namespace WeFly
{
    public class StateMachine
    {
        /// <summary>
        /// 状态列表
        /// </summary>
        protected Dictionary<uint, State> mStates = new Dictionary<uint, State>();

        /// <summary>
        /// 当前状态
        /// </summary>
        protected State mCurrentState;

        public State CurrentState
        {
            get { return mCurrentState; }
        }

        /// <summary>
        /// 判断状态
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
        /// 获取状态
        /// </summary>
        /// <param name="type">状态类型</param>
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
        /// 初始化
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
        /// 反初始化
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
        /// 更新状态
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
        /// 切换状态，允许状态重入，即新旧状态相同时，仍执行状态切换
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
        /// 停止当前状态，切换到空状态
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
        /// 注册状态
        /// </summary>
        /// <param name="type">状态类型</param>
        /// <param name="state">状态实例</param>
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
        /// 反注册状态
        /// </summary>
        /// <param name="type">状态类型</param>
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