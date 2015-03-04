/************************************************
 *
 * file  : State.cs
 * author: bobding
 * date  : 2015-01-20
 * detail: 状态基类
 *
************************************************/

namespace WeFly
{
    /// <summary>
    /// 状态基类
    /// </summary>
    public class State
    {
        /// <summary>
        /// 状态类型
        /// </summary>
        protected uint mStateType = 0;

        public uint StateType
        {
            get { return mStateType; }
            set { mStateType = value; }
        }

        /// <summary>
        /// 初始化状态
        /// </summary>
        /// <returns></returns>
        public virtual bool Initialize()
        {
            return true;
        }

        /// <summary>
        /// 反初始化状态
        /// </summary>
        /// <returns></returns>
        public virtual bool UnInitialize()
        {
            return true;
        }

        /// <summary>
        /// 进入状态
        /// </summary>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        public virtual void Enter(object arg0, object arg1)
        {

        }

        /// <summary>
        /// 离开状态
        /// </summary>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        public virtual void Leave(object arg0, object arg1)
        {

        }

        /// <summary>
        /// 状态更新
        /// </summary>
        /// <param name="delta"></param>
        public virtual void Update(float delta)
        {

        }
    }
}