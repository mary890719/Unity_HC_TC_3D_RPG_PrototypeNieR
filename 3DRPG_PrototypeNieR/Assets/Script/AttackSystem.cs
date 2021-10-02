using Invector.vCharacterController;
using UnityEngine;

/// <summary>
/// �����t��
/// �T�q�����P����
/// �P�_�ܨ��e��M�w�����Ҧ�
/// </summary>
public class AttackSystem : MonoBehaviour
{
    #region ���G���}
    [Header("�ѼƦW��")]
    public string parAttackPart = "����q��";
    public string parAttackGather = "���𶰮�";
    [Header("�s�����j���ݮɶ�"), Range(0, 2)]
    public float[] intervalBetweenAttackPart = { 0.5f, 0.5f, 0.7f };
    [Header("����ɶ�"), Range(0, 2)]
    public float timeToAttackGather = 1;
    [Header("�����q��"), Range(0, 10)]
    public int countAttackPartMax = 3;
    public vThirdPersonController v;
    public AvatarMask am;
    #endregion

    #region ���G�p�H
    private Animator ani;
    /// <summary>
    /// �������a���U���䪺�ɶ�
    /// </summary>
    private float timerAttackGather;
    /// <summary>
    /// �s�q�����ϥΪ��p�ɾ�
    /// </summary>
    private float timerAttackPart;
    /// <summary>
    /// �����q��
    /// </summary>
    private int countAttackPart;
    #endregion

    #region �ƥ�
    // ����ƥ�G�C�������H�� Start ���椧�e����@��
    private void Awake()
    {
        ani = GetComponent<Animator>();
    }

    // �}�l�ƥ�G�C�������H�� Awake ���椧�����@��
    private void Start()
    {

    }

    private void Update()
    {
        ClickTime();
    }
    #endregion

    #region ��k�G�p�H
    // VS �榡�� �ƪ��GCtrl + K D
    /// <summary>
    /// �I����ɶ����֥[
    /// </summary>
    private void ClickTime()
    {
        // �ܨ���A�����Ҧ����ܨ������
        // ���o��L�}����T���覡
        // 1. �M�䪫��è��o���󪺸��
        //bool isTransfrom = GameObject.Find("�ܨ��t��").GetComponent<TransformSystem>().isTransform;
        // 2. �N�n���o����Ƨאּ�R�A
        bool isTransfrom = TransfromSystem.isTransform;

        if (isTransfrom && Input.GetKeyDown(KeyCode.Mouse0))
        {
            ani.SetTrigger("�ܨ������");
            return;
        }

        // �ܨ��e�A�����Ҧ����ܨ��e����
        if (Input.GetKey(KeyCode.Mouse0))                   // ���� ����
        {
            timerAttackGather += Time.deltaTime;            // �֥[ �p�ɾ�����
            timerAttackPart += Time.deltaTime;              // �֥[ �p�ɾ��q��
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))            // ��} ����
        {
            if (timerAttackGather >= timeToAttackGather)    // �p�G �p�ɾ�>= ����ɶ�
            {
                AttackGather();
            }
            else                                            // �_�h
            {
                AttackPart();
            }

            timerAttackGather = 0;                          // �p�ɾ� �k�s
        }
    }

    /// <summary>
    /// �������
    /// </summary>
    private void AttackGather()
    {
        ani.SetTrigger(parAttackGather);
    }

    /// <summary>
    /// �����q��
    /// </summary>
    private void AttackPart()
    {
        if (timerAttackPart <= intervalBetweenAttackPart[countAttackPart])              // �p�G �p�ɾ��q�� <= �q�ƶ��j
        {
            CancelInvoke();                                                             // ���� 
            Invoke("RestoreAttackPartCountToZero", 1.5f);                               // ����I�s
            countAttackPart++;                                                          // �W�[�q��            
        }
        else                                                                            // �_�h
        {
            countAttackPart = 0;                                                        // �q���k�s
        }

        timerAttackPart = 0;                                                            // �p�ɾ��k�s
        ani.SetInteger(parAttackPart, countAttackPart);                                 // ��s�q�ưѼ�
        if (countAttackPart == countAttackPartMax) countAttackPart = 0;                 // 
    }

    /// <summary>
    /// ��_�����q�Ƭ��s
    /// </summary>
    private void RestoreAttackPartCountToZero()
    {
        countAttackPart = 0;
        ani.SetInteger(parAttackPart, countAttackPart);
    }
    #endregion
}
