using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Rendering;

/// <summary>
/// ��ܨt��
/// 1. �M�w���ܪ̦W��
/// 2. �M�w��ܤ��e - �i�H���h�q
/// 3. ��ܨC�Ӭq����e�������ϥܰʺA�ĪG
/// </summary>
public class DialogueSystem : MonoBehaviour
{
    #region ���
    [Header("��ܸ��")]
    public DialogueData data;
    [Header("��ܶ��j"), Range(0, 3)]
    public float interval = 0.2f;
    [Header("��ܧ����ϥ�")]
    public GameObject goFinishIcon;
    [Header("��r�����G���ܪ̦W�١B��ܤ�r���e")]
    public Text textTalker;
    public Text textContent;
    [Header("�~���ܪ�����")]
    public KeyCode kcContinute = KeyCode.Space;
    [Header("���r����")]
    public AudioClip soundType;
    [Header("���r���q"), Range(0, 2)]
    public float volume = 1;

    private AudioSource aud;

    /// <summary>
    /// ��ܨt�εe���G�s�դ���
    /// </summary>
    private CanvasGroup groupDialogue;
    #endregion

    private void Start()
    {
        aud = GetComponent<AudioSource>();
        groupDialogue = transform.GetChild(0).GetComponent<CanvasGroup>();

        startDialogue();
    }

    /// <summary>
    /// �}�l���
    /// </summary>
    private void startDialogue()
    {
        StartCoroutine(ShowEveryDialogue());
    }

    /// <summary>
    /// ��ܨC�q��ܡA�æb�q���������ݪ��a���~�����
    /// </summary>
    private IEnumerator ShowEveryDialogue()
    {
        groupDialogue.alpha = 1;                                                // ��ܹ�ܵe�� - �z���׬� 1
        textTalker.text = data.diaogueTalerName;                                // ��s��ܪ̦W��
        textContent.text = "";                                                  // ��ܤ��e�M��

        for(int i=0;i<data.diaogueContents.Length;i++)                          // �j�����C�Ӭq��
        {
            for (int j = 0; j < data.diaogueContents[i].Length; j++)            // �j�����C�Ӭq�������C�@�Ӧr
            {
                textContent.text += (data.diaogueContents[i][j]);               // ��s��ܤ��e
                aud.PlayOneShot(soundType, volume);                             // ���񭵮�
                yield return new WaitForSeconds(interval);                      // ���r���j
            }

            goFinishIcon.SetActive(true);                                       // �C�ӹ�ܧ�������ܧ����ϥ�

            while (!Input.GetKeyDown(kcContinute))                              // ���� ���a���~����s - �ϥ� null ���C�V���ɶ�
            {
                yield return null;                                              
            }

            textContent.text = "";                                              // ���a���U�ť����M�Ź�ܤ��e
            goFinishIcon.SetActive(false);                                      // ���������ϥ�

            if (i == data.diaogueContents.Length - 1) groupDialogue.alpha = 0;  // �p�G��ܬq���w�g�����N������ܤ���
        }
    }
}
