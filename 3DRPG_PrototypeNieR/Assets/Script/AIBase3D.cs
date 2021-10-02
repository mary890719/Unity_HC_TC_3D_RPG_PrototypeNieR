using UnityEngine;
using UnityEngine.AI;
using System.Collections;

/// <summary>
/// AI �� 3D �Ҧ�
/// ���ݡB�樫�B�l�ܪ��a�B�����B���˻P���`
/// </summary>
public class AIBase3D : MonoBehaviour
{
    #region ���G���}
    [Header("���ʳt��"), Range(0, 500)]
    public float speed = 3;
    [Header("�����O"), Range(0, 500)]
    public float attack = 50;
    [Header("��q"), Range(0, 500)]
    public float hp = 300;
    [Header("�l�ܽd��"), Range(0, 100)]
    public float rangeTrack = 10;
    [Header("�����d��"), Range(0, 100)]
    public float rangeAttack = 2.5f;
    [Header("�����N�o"), Range(0, 10)]
    public float cdAttack = 3.5f;
    [Header("���۳t��"), Range(0, 10)]
    public float turn = 2.5f;
    [Header("�����d��ؤo�P�첾")]
    public Vector3 areaAttackSize = Vector3.one;
    public Vector3 areaAttackOffset;
    [Header("�ǰe�ˮ`���ؼЪ�����ɶ�"), Range(0, 2)]
    public float delaySendAttackToTarget = 0.3f;
    #endregion

    #region ���G�p�H
    private Animator ani;
    private NavMeshAgent nav;
    private Transform target;
    private float timerAttack;
    #endregion

    #region �ƥ�
    private void Awake()
    {
        ani = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        nav.speed = speed;
        nav.stoppingDistance = rangeAttack;
        timerAttack = cdAttack;
    }

    private void OnDrawGizmos()
    {
        #region �l�ܻP�����d��
        Gizmos.color = new Color(0, 1, 0.2f, 0.3f);
        Gizmos.DrawSphere(transform.position, rangeTrack);

        Gizmos.color = new Color(1, 0, 0.2f, 0.3f);
        Gizmos.DrawSphere(transform.position, rangeAttack);
        #endregion

        #region �����d��
        Gizmos.color = new Color(0.2f, 0, 1, 0.3f);
        Gizmos.matrix = Matrix4x4.TRS(
            transform.position + transform.right * areaAttackOffset.x +
            transform.up * areaAttackOffset.y +
            transform.forward * areaAttackOffset.z,
            transform.rotation, transform.localScale);
        Gizmos.DrawCube(Vector3.zero, areaAttackSize);
        #endregion
    }

    private void Update()
    {
        CheckTargetIsInTrackRange();
        Track();
        Attack();
    }
    #endregion

    #region ��k�G���}
    #endregion

    #region ��k�G�p�H
    /// <summary>
    /// �ˬd�ؼЪ��O�_�i�J�l�ܽd��
    /// </summary>
    private void CheckTargetIsInTrackRange()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, rangeTrack, 1 << 3);

        if (hits.Length > 0) target = hits[0].transform;    // ���a�i�J���x�s�ؼи�T
        else target = null;                                // ���}��N�ؼи�T�]���ŭ�
    }

    /// <summary>
    /// �l�ܥؼ�
    /// </summary>
    private void Track()
    {
        if (target)
        {
            nav.isStopped = false;
            nav.SetDestination(target.position);
        }
        else
        {
            nav.isStopped = true;
        }

        ani.SetBool("�����}��", !nav.isStopped);
    }

    /// <summary>
    /// �����欰
    /// �ˬd�ؼЬO�_�b�����d��
    /// �i������P�N�o�B�z�åB���V���a
    /// </summary>
    private void Attack()
    {
        if (!target) return;

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance <= rangeAttack)
        {
            if (timerAttack >= cdAttack)
            {
                ani.SetTrigger("����Ĳ�o");
                timerAttack = 0;
                StartCoroutine(AttackAreaCheck());
            }
            else
            {
                timerAttack += Time.deltaTime;
                ani.SetBool("�����}��", false);
            }

            LookAtTarget();
        }
    }

    /// <summary>
    /// �����ϰ��ˬd�A�ˬd�O�_�������ؼ�
    /// </summary>
    private IEnumerator AttackAreaCheck()
    {
        yield return new WaitForSeconds(delaySendAttackToTarget);

        Collider[] hits = Physics.OverlapBox(
            transform.position +
            transform.right * areaAttackOffset.x +
            transform.up * areaAttackOffset.y +
            transform.forward * areaAttackOffset.z,
            areaAttackSize / 2, Quaternion.identity, 1 << 3);

        hits[0].GetComponent<DamageSystem>().Damage(attack);
    }

    private void LookAtTarget()
    {
        Vector3 posTarget = target.position;        // ���o�ؼЮy��
        posTarget.y = transform.position.y;         // �N�ؼЮy��Y�b�]�w���P���Ǫ��P��
        Quaternion lookRotation = Quaternion.LookRotation(posTarget - transform.position);                  // �ϥΦV�q���o����
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, turn * Time.deltaTime);      // ���״���
    }
    #endregion
}
