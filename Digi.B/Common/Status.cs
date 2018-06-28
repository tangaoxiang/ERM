using System;
using System.Collections.Generic;

namespace Digi.B {
    /// <summary>
    /// �ж�TreeViewѡ�е�״̬
    /// </summary>
    public enum ETreeViewSynStatus {
        /// <summary>
        /// ������Ϣ
        /// </summary>
        GCXX = 1,
        /// <summary>
        /// ���ߴ���
        /// </summary>
        PIPELX,
        /// <summary>
        /// ��������
        /// </summary>
        PIPE,
        /// <summary>
        /// ������
        /// </summary>
        LineID,
        /// <summary>
        /// ֧����
        /// </summary>
        LineIDother
    }

    /// <summary>
    /// ϵͳ����״̬
    /// </summary>
    public enum ESystemSynStatus {
        /// <summary>
        /// ���״̬
        /// </summary>
        ReadOnly = 1,
        /// <summary>
        /// ���ڱ༭��û�п�ʼ�༭
        /// </summary>
        Edit,
        /// <summary>
        /// ���ڱ༭
        /// </summary>
        Editing,
        /// <summary>
        /// ����״̬
        /// </summary>
        End
    }

    /// <summary>
    /// ���м�¼״̬�Ķ���ö��
    /// </summary>
    public enum ESaveASynStatus {
        Catalog
    }

    /// <summary>
    /// ����״̬����
    /// </summary>
    public abstract class Status{
        /// <summary>
        /// ��������״̬����
        /// </summary>
        public delegate void EnterHandle(object sender);
        /// <summary>
        /// �����뿪��״̬����
        /// </summary>
        public delegate void LeaveHandle(object sender);
        /// <summary>
        /// ��������״̬����
        /// </summary>
        public delegate void EndHandle(object sender);

        /// <summary>
        /// ���캯��
        /// </summary>
        protected Status(){}
    }

    /// <summary>
    /// ����ϵͳ״̬����,��������������״̬<see cref="DigiPower.PIPE.ESystemSynStatus"/>,
    /// ���н�ȥ���뿪�ͽ����¼�
    /// </summary>
    public class SystemSynStatus:Status {
        /// <summary>
        /// ��������״̬�¼�
        /// </summary>
        public event EnterHandle Enter;
        /// <summary>
        /// �����뿪��״̬�¼�
        /// </summary>
        public event LeaveHandle Leave;
        /// <summary>
        /// ��������״̬�¼�
        /// </summary>
        public event EndHandle End;

        private Digi.B.ESystemSynStatus pStatus;
        private Stack<ESystemSynStatus> pStack;
        //protected int pTimeOut;

        /// <summary>
        /// ϵͳ����״̬
        /// </summary>
        public Digi.B.ESystemSynStatus PStatus {
            get { return pStatus; }
            set { this.OnEnter(value); PStack.Push(value); }
        }

        /// <summary>
        /// ״̬ջ
        /// </summary>
        public Stack<ESystemSynStatus> PStack {
            get { return pStack; }
            set { pStack = value; }
        } 

        /// <summary>
        /// ���캯��
        /// </summary>
        public SystemSynStatus()
            : this(Digi.B.ESystemSynStatus.ReadOnly) {
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        public SystemSynStatus(Digi.B.ESystemSynStatus pStatus) {
            pStack = new Stack<ESystemSynStatus>();
            PStatus = this.pStatus;
        }
        
        /// <summary>
        /// �ı䵱ǰ״̬
        /// </summary>
        protected void OnEnter(Digi.B.ESystemSynStatus pStatus) {
            if (pStatus != Digi.B.ESystemSynStatus.End && this.pStatus != pStatus) {
                this.OnChange(pStatus);
            }
        }

        /// <summary>
        /// �ı�״̬����
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
        /// ����״̬
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
    /// ����TreeView״̬����,��������������״̬<see cref="DigiPower.PIPE.ETreeViewSynStatus"/>,
    /// ���н�ȥ���뿪�ͽ����¼�
    /// </summary>
    public class TreeViewSynStatus : Status {
        /// <summary>
        /// ��������״̬�¼�
        /// </summary>
        public event EnterHandle Enter;
        /// <summary>
        /// �����뿪��״̬�¼�
        /// </summary>
        public event LeaveHandle Leave;
        /// <summary>
        /// ��������״̬�¼�
        /// </summary>
        public event EndHandle End;

        private Digi.B.ETreeViewSynStatus pStatus;
        private Stack<ETreeViewSynStatus> pStack;
        //protected int pTimeOut;

        /// <summary>
        /// ϵͳ����״̬(��״̬�ĸı�ᴥ��һ�������¼�)
        /// </summary>
        public Digi.B.ETreeViewSynStatus PStatus {
            get { return pStatus; }
            set { this.OnEnter(value); PStack.Push(value); }
        }

        /// <summary>
        /// ״̬ջ
        /// </summary>
        public Stack<ETreeViewSynStatus> PStack {
            get { return pStack; }
            set { pStack = value; }
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        public TreeViewSynStatus()
            : this(Digi.B.ETreeViewSynStatus.GCXX) {
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        public TreeViewSynStatus(Digi.B.ETreeViewSynStatus pStatus) {
            PStack = new Stack<ETreeViewSynStatus>();
            PStatus = this.pStatus;
        }

        /// <summary>
        /// �ı䵱ǰ״̬
        /// </summary>
        protected void OnEnter(Digi.B.ETreeViewSynStatus pStatus) {
            if (this.pStatus != pStatus) {
                this.OnChange(pStatus);
            }
        }

        /// <summary>
        /// �ı�״̬����
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
        /// ����״̬
        /// </summary>
        protected void OnEnd() {
            if (null != this.Leave)
                this.Leave(this);
            if (null != this.End)
                this.End(this);
        }
    }

    /// <summary>
    /// �첽Save״̬����,��������������״̬<see cref="DigiPower.PIPE.Operator.SaveASynStatus"/>,
    /// ���н�ȥ���뿪�ͽ����¼�
    /// </summary>
    public class SaveASynStatus : Status {
        /// <summary>
        /// ��������״̬����
        /// </summary>
        public new delegate void EnterHandle(ESaveASynStatus sender, bool e);
        /// <summary>
        /// �����뿪��״̬����
        /// </summary>
        public new delegate void LeaveHandle(ESaveASynStatus sender, bool e);
        /// <summary>
        /// ��������״̬����
        /// </summary>
        public new delegate void EndHandle(ESaveASynStatus sender);

        /// <summary>
        /// ��������״̬�¼�
        /// </summary>
        public event EnterHandle Enter;
        /// <summary>
        /// �����뿪��״̬�¼�
        /// </summary>
        public event LeaveHandle Leave;
        /// <summary>
        /// ��������״̬�¼�
        /// </summary>
        public event EndHandle End;

        private bool[] pSave;

        /// <summary>
        /// ���캯��
        /// </summary>
        public SaveASynStatus()
            : this(new bool[] { true }) {
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        public SaveASynStatus(bool[] pSave) {
            this.pSave = pSave;
        }

        /// <summary>
        /// ��ȡָ��<see cref="DigiPower.PIPE.ESaveASynStatus"/>���͵�״̬
        /// </summary>
        /// <param name="pSave"><see cref="DigiPower.PIPE.ETreeViewSynStatus"/>����</param>
        /// <returns>bool</returns>
        public bool GetSaveStatus(ESaveASynStatus pSave) {
            return this.pSave[(int)pSave];
        }

        /// <summary>
        /// ��<see cref="DigiPower.PIPE.ESaveASynStatus"/>���ͱ�Ϊ��¼״̬
        /// </summary>
        /// <param name="pSave"><see cref="DigiPower.PIPE.ESaveASynStatus"/>����</param>
        public void Save(ESaveASynStatus pSave) {
            if (!this.pSave[(int)pSave]) {
                this.OnSave(pSave);
            }
        }

        /// <summary>
        /// ��<see cref="DigiPower.PIPE.ESaveASynStatus"/>���ͱ�Ϊ�༭״̬
        /// </summary>
        /// <param name="pSave"><see cref="DigiPower.PIPE.ESaveASynStatus"/>����</param>
        public void Edit(ESaveASynStatus pSave) {
            if (this.pSave[(int)pSave]) {
                this.OnEdit(pSave);
            }
        }

        /// <summary>
        ///  ��ȫ��<see cref="DigiPower.PIPE.ESaveASynStatus"/>���ͱ�Ϊ��¼״̬
        /// </summary>
        public void SaveAll() {
            for (int i = 0; i < this.pSave.Length; i++)
                this.OnSave((ESaveASynStatus)i);
        }

        /// <summary>
        ///  ��ȫ��<see cref="DigiPower.PIPE.ESaveASynStatus"/>���ͱ�Ϊ�༭״̬
        /// </summary>
        public void EditAll() {
            for (int i = 0; i < this.pSave.Length; i++)
                this.OnEdit((ESaveASynStatus)i);
        }

        /// <summary>
        /// ǿ�ƽ���������״̬
        /// <example>
        /// ����:�ڱ�����ʾ�򵯳�ʱ�û����ȡ��,�ᴥ�����¼�
        /// </example>
        /// </summary>
        public void Finish() {
            for (int i = 0; i < this.pSave.Length; i++) {
                this.OnEnd((ESaveASynStatus)i);
            }
        }

        /// <summary>
        /// �Ƿ�ȫ����Ϊ����״̬
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
        /// ����״̬
        /// </summary>
        protected void OnEnd(ESaveASynStatus pSave) {
            this.pSave[(int)pSave] = true;
            if (null != this.End) {
                this.End(pSave);
            }
        }
    }
}
