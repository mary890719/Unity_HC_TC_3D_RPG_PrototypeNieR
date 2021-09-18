using UnityEngine;
using Invector.vCharacterController;

public class TransfromSystem : MonoBehaviour
{
    #region 欄位：公開
    [Header("玩家變身前後模型物件")]
    public GameObject goTransfromBefore;
    public GameObject goTransfromAfter;
    [Header("攝影機")]
    public vThirdPersonCamera cam;
    #endregion

    #region 欄位：私人    
    #endregion

    #region 事件
    private void Update()
    {
        TransformSwitch();
    }
    #endregion

    #region 方法：私人
    /// <summary>
    /// 變身切換
    /// 按下變身按鈕 R 對調模型
    /// </summary>
    private void TransformSwitch()
    {
        // 按下 R 鍵，變身前後模型 顯示狀態 與 原本 顛倒
        if (Input.GetKey(KeyCode.R))
        {
            goTransfromBefore.SetActive(!goTransfromBefore.activeInHierarchy);
            goTransfromAfter.SetActive(!goTransfromAfter.activeInHierarchy);

            // 攝影機 目標 設定為 目前顯示的模型
            if (goTransfromBefore.activeInHierarchy) cam.SetTarget(goTransfromBefore.transform);
            else if (goTransfromAfter.activeInHierarchy) cam.SetTarget(goTransfromAfter.transform);

            // 同步座標
            // goTransfromBefore.transform.position = goTransfromAfter.transform.position;
            // goTransfromAfter.transform.position = goTransfromBefore.transform.position;
        }
    }
    #endregion
}
