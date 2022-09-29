using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pape : MonoBehaviour
{
    public Animator animator;
    public GameObject jogador;
    public GameObject cursor;
    public Transform LugardelPaPe;
    public float RangodelPaPe = 0.6f;
    public LayerMask EnemyLayer;
    private float papeCD;
    public int DVdmg = 200;
    public int ssdmg = 100;
    public Transform FirePoint;
    public LineRenderer LineRenderer;
    public Animator Animator;
    private bool papenormal = true;
    private bool darkdancer = false;
    private bool everlastingdance = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && Time.time > papeCD + 0.40f)
        {
            if (papenormal == false && darkdancer == true)
            {
                Animator.SetTrigger("DDAttack");
                papeCD = 0;
            }
            else if (papenormal == false && everlastingdance == true)
            {

            }
            else
            {
                Attack();
            }
            papeCD = Time.time;
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            OnAttack();


        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            OnAttack();

        }
    }

    void Attack()
    {
        Animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(LugardelPaPe.position, RangodelPaPe, EnemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("pape" + enemy.name);

        }
    }
    private void OnDrawGizmosSelected() //esta wea es para ver el rango del pape
    {
        if (LugardelPaPe == null)
            return;
        Gizmos.DrawWireSphere(LugardelPaPe.position, RangodelPaPe);
    }

    //supers hacer un voidStart para elegirlas al inicio o con items
    public void DarkDancer() //Staffsuper
    {
        papenormal = false;
        darkdancer = true;
        Debug.Log("darkdancer");

    }
    void TheEverlastingDance() //Odachisuper
    {

    }
    void ShootingStar() //Revolversuper
    {

    }
    void TheDiyingVoice() //LeverActionRiflesuper
    {

    }
   
    void OnAttack()
    {
        //direccion del pape
        Vector3 direction = jogador.transform.position - cursor.transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(-0.25f, 0.2f, 1.0f);
        else transform.localScale = new Vector3(0.25f, 0.2f, 1.0f);

    }
    void DDattack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(LugardelPaPe.position, RangodelPaPe, EnemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("DDpape" + enemy.name);

        }
    }
}



