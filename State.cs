/************************************************
 *
 * file  : State.cs
 * author: bobding
 * date  : 2015-01-20
 * detail: ״̬����
 *
************************************************/

namespace WeFly
{
    /// <summary>
    /// ״̬����
    /// </summary>
    public class State
    {
        /// <summary>
        /// ״̬����
        /// </summary>
        protected uint mStateType = 0;

        public uint StateType
        {
            get { return mStateType; }
            set { mStateType = value; }
        }

        /// <summary>
        /// ��ʼ��״̬
        /// </summary>
        /// <returns></returns>
        public virtual bool Initialize()
        {
            return true;
        }

        /// <summary>
        /// ����ʼ��״̬
        /// </summary>
        /// <returns></returns>
        public virtual bool UnInitialize()
        {
            return true;
        }

        /// <summary>
        /// ����״̬
        /// </summary>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        public virtual void Enter(object arg0, object arg1)
        {

        }

        /// <summary>
        /// �뿪״̬
        /// </summary>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        public virtual void Leave(object arg0, object arg1)
        {

        }

        /// <summary>
        /// ״̬����
        /// </summary>
        /// <param name="delta"></param>
        public virtual void Update(float delta)
        {

        }
    }
}