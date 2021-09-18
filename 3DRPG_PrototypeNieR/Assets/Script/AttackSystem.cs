using UnityEngine;

/// <summary>
/// �����t��
/// �T�q�����P����
/// </summary>
public class AttackSystem : MonoBehaviour
{
    #region ���G���}
    [Header("�ѼƦW��")]
    public string parAttackPart = "����q��";
    public string parAttackGather = "���𶰮�";
    [Header("�s�����j���ݮɶ�"), Range(0, 2)]
    public float intervalBetweenAttackPart = 0.2f;
    [Header("����ɶ�"), Range(0, 2)]
    public float timeToAttackGather = 1;
    #endregion

    #region ���G�p�H
    private Animator ani;
    /// <summary>
    /// �������a���U���䪺�ɶ�
    /// </summary>
    private float timer;
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
        if (Input.GetKey(KeyCode.Mouse0))                   // ���� ����
        {
            timer += Time.deltaTime;                        // �֥[ �p�ɾ�
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))            // ��} ����
        {
            if (timer >= timeToAttackGather)                // �p�G �p�ɾ�>= ����ɶ�
            {
                AttackGather();
            }
            else                                            // �_�h
            {
                print("�����ɶ�����");
            }

            timer = 0;                                      // �p�ɾ� �k�s
        }

        print("���U���䪺�ɶ��G" + timer);
    }

    /// <summary>
    /// �������
    /// </summary>
    private void AttackGather()
    {
        ani.SetTrigger(parAttackGather);
    }
    #endregion

    #region ��k�G���}

    #endregion
}
