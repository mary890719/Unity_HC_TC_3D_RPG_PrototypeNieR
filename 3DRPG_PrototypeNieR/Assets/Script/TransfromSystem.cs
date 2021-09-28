using UnityEngine;
using Invector.vCharacterController;

public class TransfromSystem : MonoBehaviour
{
    #region ���G���}
    [Header("���a�ܨ��e��ҫ�����")]
    public GameObject goTransfromBefore;
    public GameObject goTransfromAfter;
    [Header("��v��")]
    public vThirdPersonCamera cam;
    #endregion

    #region �R�A���
    // �R�A��ƯS��
    // 1. ���|����ݩʭ��O
    // 2. ���������ɤ��|�٭�
    // 3. �s���覡 - ���O.�R�A��ƦW��
    /// <summary>
    /// �R�A��ơG�O�_�ܨ��ATrue �N���ܨ���AFalse �N���ܨ��e
    /// </summary>
    public static bool isTransform;
    #endregion
    
    #region ���G�p�H    
    #endregion

    #region �ƥ�
    private void Update()
    {
        TransformSwitch();
    }
    #endregion

    #region ��k�G�p�H
    /// <summary>
    /// �ܨ�����
    /// ���U�ܨ����s R ��ռҫ�
    /// </summary>
    private void TransformSwitch()
    {
        // ���U R ��A�ܨ��e��ҫ� ��ܪ��A �P �쥻 �A��
        if (Input.GetKey(KeyCode.R))
        {
            // �ܨ����L�� �ܬ������� �ۤϭ�
            isTransform = !isTransform;

            // �p�G �ܨ��e �O���� �N�N �ܨ��e���y�лP���� �]�w�P �ܨ���ۦP
            if (!goTransfromBefore.activeInHierarchy)
            {
                goTransfromBefore.transform.position = goTransfromAfter.transform.position;
                goTransfromBefore.transform.eulerAngles = goTransfromAfter.transform.eulerAngles;
            }
            // �p�G �ܨ��� �O���� �N�N �ܨ��᪺�y�лP���� �]�w�P �ܨ��e�ۦP
            else if (!goTransfromAfter.activeInHierarchy)
            {
                goTransfromAfter.transform.position = goTransfromBefore.transform.position;
                goTransfromAfter.transform.eulerAngles = goTransfromBefore.transform.eulerAngles;
            }

            goTransfromBefore.SetActive(!goTransfromBefore.activeInHierarchy);
            goTransfromAfter.SetActive(!goTransfromAfter.activeInHierarchy);

            // ��v�� �ؼ� �]�w�� �ثe��ܪ��ҫ�
            if (goTransfromBefore.activeInHierarchy) cam.SetTarget(goTransfromBefore.transform);
            else if (goTransfromAfter.activeInHierarchy) cam.SetTarget(goTransfromAfter.transform);

            
        }
    }
    #endregion
}
