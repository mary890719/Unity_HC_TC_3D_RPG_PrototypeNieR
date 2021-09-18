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
            goTransfromBefore.SetActive(!goTransfromBefore.activeInHierarchy);
            goTransfromAfter.SetActive(!goTransfromAfter.activeInHierarchy);

            // ��v�� �ؼ� �]�w�� �ثe��ܪ��ҫ�
            if (goTransfromBefore.activeInHierarchy) cam.SetTarget(goTransfromBefore.transform);
            else if (goTransfromAfter.activeInHierarchy) cam.SetTarget(goTransfromAfter.transform);

            // �P�B�y��
            // goTransfromBefore.transform.position = goTransfromAfter.transform.position;
            // goTransfromAfter.transform.position = goTransfromBefore.transform.position;
        }
    }
    #endregion
}
