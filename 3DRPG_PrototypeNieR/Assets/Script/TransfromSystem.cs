using UnityEngine;

public class TransfromSystem : MonoBehaviour
{
    #region ���G���}
    [Header("���a�ܨ��e��ҫ�����")]
    public GameObject goTransfromBefore;
    public GameObject goTransfromAfter;
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
        }
    }
    #endregion
}
