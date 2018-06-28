using System;
using System.Collections.Generic;

namespace Digi.B {
    /// <summary>
    /// 判断TreeView选中的状态
    /// </summary>
    public enum ETreeViewSynStatus {
        /// <summary>
        /// 工程信息
        /// </summary>
        GCXX = 1,
        /// <summary>
        /// 管线大类
        /// </summary>
        PIPELX,
        /// <summary>
        /// 管线子类
        /// </summary>
        PIPE,
        /// <summary>
        /// 主管线
        /// </summary>
        LineID,
        /// <summary>
        /// 支管线
        /// </summary>
        LineIDother
    }

    /// <summary>
    /// 系统互斥状态
    /// </summary>
    public enum ESystemSynStatus {
        /// <summary>
        /// 浏览状态
        /// </summary>
        ReadOnly = 1,
        /// <summary>
        /// 处于编辑并没有开始编辑
        /// </summary>
        Edit,
        /// <summary>
        /// 正在编辑
        /// </summary>
        Editing,
        /// <summary>
        /// 结束状态
        /// </summary>
        End
    }

    /// <summary>
    /// 含有记录状态的对象枚举
    /// </summary>
    public enum ESaveASynStatus {
        Catalog
    }

    /// <summary>
    /// 抽象状态对象
    /// </summary>
    public abstract class Status{
        /// <summary>
        /// 触发进入状态函数
        /// </summary>
        public delegate void EnterHandle(object sender);
        /// <summary>
        /// 触发离开该状态函数
        /// </summary>
        public delegate void LeaveHandle(object sender);
        /// <summary>
        /// 触发结束状态函数
        /// </summary>
        public delegate void EndHandle(object sender);

        /// <summary>
        /// 构造函数
        /// </summary>
        protected Status(){}
    }

    /// <summary>
    /// 互斥系统状态对象,其类型所包含的状态<see cref="DigiPower.PIPE.ESystemSynStatus"/>,
    /// 现有进去、离开和结束事件
    /// </summary>
    public class SystemSynStatus:Status {
        /// <summary>
        /// 触发进入状态事件
        /// </summary>
        public event EnterHandle Enter;
        /// <summary>
        /// 触发离开该状态事件
        /// </summary>
        public event LeaveHandle Leave;
        /// <summary>
        /// 触发结束状态事件
        /// </summary>
        public event EndHandle End;

        private Digi.B.ESystemSynStatus pStatus;
        private Stack<ESystemSynStatus> pStack;
        //protected int pTimeOut;

        /// <summary>
        /// 系统所在状态
        /// </summary>
        public Digi.B.ESystemSynStatus PStatus {
            get { return pStatus; }
            set { this.OnEnter(value); PStack.Push(value); }
        }

        /// <summary>
        /// 状态栈
        /// </summary>
        public Stack<ESystemSynStatus> PStack {
            get { return pStack; }
            set { pStack = value; }
        } 

        /// <summary>
        /// 构造函数
        /// </summary>
        public SystemSynStatus()
            : this(Digi.B.ESystemSynStatus.ReadOnly) {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public SystemSynStatus(Digi.B.ESystemSynStatus pStatus) {
            pStack = new Stack<ESystemSynStatus>();
            PStatus = this.pStatus;
        }
        
        /// <summary>
        /// 改变当前状态
        /// </summary>
        protected void OnEnter(Digi.B.ESystemSynStatus pStatus) {
            if (pStatus != Digi.B.ESystemSynStatus.End && this.pStatus != pStatus) {
                this.OnChange(pStatus);
            }
        }

        /// <summary>
        /// 改变状态函数
        /// </summary>
        /// <param name="pStatus"></param>
        protected void OnChange(Digi.B.ESystemSynStatus pStatus) {
            if (null != this.Leave)
                this.Leave(this);
            this.pStatus = pStatus;
            if (null != this.Enter)
                this.Enter(this);
        }

        /// <summary>
        /// 结束状态
        /// </summary>
        protected void OnEnd() {
            this.pStatus = Digi.B.ESystemSynStatus.End;
            if (null != this.Leave)
                this.Leave(this);
            if (null != this.End)
                this.End(this);
        }
    }

    /// <summary>
    /// 互斥TreeView状态对象,其类型所包含的状态<see cref="DigiPower.PIPE.ETreeViewSynStatus"/>,
    /// 现有进去、离开和结束事件
    /// </summary>
    public class TreeViewSynStatus : Status {
        /// <summary>
        /// 触发进入状态事件
        /// </summary>
        public event EnterHandle Enter;
        /// <summary>
        /// 触发离开该状态事件
        /// </summary>
        public event LeaveHandle Leave;
        /// <summary>
        /// 触发结束状态事件
        /// </summary>
        public event EndHandle End;

        private Digi.B.ETreeViewSynStatus pStatus;
        private Stack<ETreeViewSynStatus> pStack;
        //protected int pTimeOut;

        /// <summary>
        /// 系统所在状态(该状态的改变会触发一连串的事件)
        /// </summary>
        public Digi.B.ETreeViewSynStatus PStatus {
            get { return pStatus; }
            set { this.OnEnter(value); PStack.Push(value); }
        }

        /// <summary>
        /// 状态栈
        /// </summary>
        public Stack<ETreeViewSynStatus> PStack {
            get { return pStack; }
            set { pStack = value; }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public TreeViewSynStatus()
            : this(Digi.B.ETreeViewSynStatus.GCXX) {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public TreeViewSynStatus(Digi.B.ETreeViewSynStatus pStatus) {
            PStack = new Stack<ETreeViewSynStatus>();
            PStatus = this.pStatus;
        }

        /// <summary>
        /// 改变当前状态
        /// </summary>
        protected void OnEnter(Digi.B.ETreeViewSynStatus pStatus) {
            if (this.pStatus != pStatus) {
                this.OnChange(pStatus);
            }
        }

        /// <summary>
        /// 改变状态函数
        /// </summary>
        /// <param name="pStatus"></param>
        protected void OnChange(Digi.B.ETreeViewSynStatus pStatus) {
            if (null != this.Leave)
                this.Leave(this);
            this.pStatus = pStatus;
            if (null != this.Enter)
                this.Enter(this);
        }

        /// <summary>
        /// 结束状态
        /// </summary>
        protected void OnEnd() {
            if (null != this.Leave)
                this.Leave(this);
            if (null != this.End)
                this.End(this);
        }
    }

    /// <summary>
    /// 异步Save状态对象,其类型所包含的状态<see cref="DigiPower.PIPE.Operator.SaveASynStatus"/>,
    /// 现有进去、离开和结束事件
    /// </summary>
    public class SaveASynStatus : Status {
        /// <summary>
        /// 触发进入状态函数
        /// </summary>
        public new delegate void EnterHandle(ESaveASynStatus sender, bool e);
        /// <summary>
        /// 触发离开该状态函数
        /// </summary>
        public new delegate void LeaveHandle(ESaveASynStatus sender, bool e);
        /// <summary>
        /// 触发结束状态函数
        /// </summary>
        public new delegate void EndHandle(ESaveASynStatus sender);

        /// <summary>
        /// 触发进入状态事件
        /// </summary>
        public event EnterHandle Enter;
        /// <summary>
        /// 触发离开该状态事件
        /// </summary>
        public event LeaveHandle Leave;
        /// <summary>
        /// 触发结束状态事件
        /// </summary>
        public event EndHandle End;

        private bool[] pSave;

        /// <summary>
        /// 构造函数
        /// </summary>
        public SaveASynStatus()
            : this(new bool[] { true }) {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public SaveASynStatus(bool[] pSave) {
            this.pSave = pSave;
        }

        /// <summary>
        /// 获取指定<see cref="DigiPower.PIPE.ESaveASynStatus"/>类型的状态
        /// </summary>
        /// <param name="pSave"><see cref="DigiPower.PIPE.ETreeViewSynStatus"/>类型</param>
        /// <returns>bool</returns>
        public bool GetSaveStatus(ESaveASynStatus pSave) {
            return this.pSave[(int)pSave];
        }

        /// <summary>
        /// 将<see cref="DigiPower.PIPE.ESaveASynStatus"/>类型变为记录状态
        /// </summary>
        /// <param name="pSave"><see cref="DigiPower.PIPE.ESaveASynStatus"/>类型</param>
        public void Save(ESaveASynStatus pSave) {
            if (!this.pSave[(int)pSave]) {
                this.OnSave(pSave);
            }
        }

        /// <summary>
        /// 将<see cref="DigiPower.PIPE.ESaveASynStatus"/>类型变为编辑状态
        /// </summary>
        /// <param name="pSave"><see cref="DigiPower.PIPE.ESaveASynStatus"/>类型</param>
        public void Edit(ESaveASynStatus pSave) {
            if (this.pSave[(int)pSave]) {
                this.OnEdit(pSave);
            }
        }

        /// <summary>
        ///  将全部<see cref="DigiPower.PIPE.ESaveASynStatus"/>类型变为记录状态
        /// </summary>
        public void SaveAll() {
            for (int i = 0; i < this.pSave.Length; i++)
                this.OnSave((ESaveASynStatus)i);
        }

        /// <summary>
        ///  将全部<see cref="DigiPower.PIPE.ESaveASynStatus"/>类型变为编辑状态
        /// </summary>
        public void EditAll() {
            for (int i = 0; i < this.pSave.Length; i++)
                this.OnEdit((ESaveASynStatus)i);
        }

        /// <summary>
        /// 强制结束并重置状态
        /// <example>
        /// 例如:在保存提示框弹出时用户点击取消,会触发该事件
        /// </example>
        /// </summary>
        public void Finish() {
            for (int i = 0; i < this.pSave.Length; i++) {
                this.OnEnd((ESaveASynStatus)i);
            }
        }

        /// <summary>
        /// 是否全部都为保存状态
        /// </summary>
        /// <returns>bool</returns>
        public bool IsAllSave() {
            foreach (bool pSave in this.pSave) {
                if (pSave == false)
                    return false;
            }
            return true;
        }

        protected void OnSave(ESaveASynStatus pSave) {
            if (null != this.Leave)
                this.Leave(pSave, false);
            this.pSave[(int)pSave] = true;
            if (null != this.Enter)
                this.Enter(pSave, true);
        }

        protected void OnEdit(ESaveASynStatus pSave) {
            if (null != this.Leave)
                this.Leave(pSave, true);
            this.pSave[(int)pSave] = false;
            if (null != this.Enter)
                this.Enter(pSave, false);
        }

        /// <summary>
        /// 结束状态
        /// </summary>
        protected void OnEnd(ESaveASynStatus pSave) {
            this.pSave[(int)pSave] = true;
            if (null != this.End) {
                this.End(pSave);
            }
        }
    }
}
