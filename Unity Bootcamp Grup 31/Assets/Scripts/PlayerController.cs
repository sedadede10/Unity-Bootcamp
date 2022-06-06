using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform Yon;
    private bool isMoving;
    private Vector3 originalPos, targetPos;
    private float timeToMove = 0.2f;//gridler arasý geçiþ zamaný
    public GirdiyiAlma inputgirdisi;
    int i;
    bool kontrol = true;
    int durum = 0;
    public Animator animator;
    public GameObject ok;
    public AudioSource ses;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !isMoving)
        {
            StartCoroutine(KodSiralama());
        }

    }
    
  
    public IEnumerator MovePlayer(Vector3 direction)//karakterin grid tabanlý hareket etmesi
    {
        isMoving = true;

        float elapsedTime = 0f;

        originalPos = transform.position;
        targetPos = originalPos + direction;

        while(elapsedTime<timeToMove)
        {
            transform.position = Vector3.Lerp(originalPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;
        
    }
    public IEnumerator ileriGitme(int tekrar)//inputtan girilen girdi sayisi kadar karakteri ileriye hareket ettrime
    {
        while (kontrol)
        {
            animator.SetBool("Front", false);
            if (i < tekrar)
            {
                StartCoroutine(MovePlayer(Vector3.up));
                ses.Play();
            }
                
            yield return new WaitForSeconds(0.5f);
            i++;
            if(i>=tekrar)
            {
                kontrol = false;
                
            }
        }
        i = 0;
        kontrol = true;
        durum = durum + 1;//bir sonraki duruma gecis yapmasi icin durum bir arttirilir
        
    }

    public IEnumerator SagaGitme(int tekrar)
    {
        while (kontrol)
        {
            animator.SetFloat("Side", 2f);
            if (i < tekrar)
            {
                StartCoroutine(MovePlayer(Vector3.right));
                ses.Play();
            }
                           
            yield return new WaitForSeconds(0.5f);
            i++;
            if (i >= tekrar)
            {
                kontrol = false;
                
            }
        }
        i = 0;
        kontrol = true;
        durum = durum + 1;
        animator.SetFloat("Side", 0f);
    }
    public IEnumerator Bullet(int tekrar)
    {
        while (kontrol)
        {
            
            if (i < tekrar)
            {
                animator.SetFloat("Attack", 2f);
                yield return new WaitForSeconds(1f);
                Instantiate(ok, transform.position, Quaternion.Euler(0f, 0f, 90f));
            }
            
            
            i++;
            if (i >= tekrar)
            {
                kontrol = false;
            }
        }
        i = 0;
        kontrol = true;
        durum = durum+1;
        animator.SetFloat("Attack", 0f);
    }
    public IEnumerator SolaGitme(int tekrar)
    {
        while (kontrol)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            animator.SetFloat("Side", 2f);
            if (i < tekrar)
            {
                StartCoroutine(MovePlayer(Vector3.left));
                ses.Play();
            }
            yield return new WaitForSeconds(0.5f);
            i++;
            if (i >= tekrar)
            {
                kontrol = false;
            }
        }
        i = 0;
        kontrol = true;
        durum = durum + 1;
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    public IEnumerator AsagiGitme(int tekrar)
    {
        while (kontrol)
        {
            animator.SetBool("Front", true);
            if (i < tekrar)
            {
                StartCoroutine(MovePlayer(Vector3.down));
                ses.Play();
            }
                
            yield return new WaitForSeconds(0.5f);
            i++;
            if (i >= tekrar)
            {
                kontrol = false;
            }
        }
        i = 0;
        kontrol = true;
        durum = 0;
        
    }

    
    public IEnumerator KodSiralama()
    {
        if(durum==0)
        {
            StartCoroutine(ileriGitme(inputgirdisi.TekrarSayisi_ileri));                       
        }
        
        yield return new WaitUntil(() => durum ==1);
        
        if (durum==1)
        {
            StartCoroutine(SolaGitme(inputgirdisi.TekrarSayisi_sola));                        
        }

        yield return new WaitUntil(() => durum == 2);

        if (durum==2)
        {
            StartCoroutine(SagaGitme(inputgirdisi.TekrarSayisi_saga));
        }

        yield return new WaitUntil(() => durum == 3);
        
        if (durum==3)
        {
            StartCoroutine(Bullet(inputgirdisi.okSayisi));
        }
        
        yield return new WaitUntil(() => durum == 4);

        if(durum==4)
        {
            StartCoroutine(AsagiGitme(inputgirdisi.TekrarSayisi_asagi));
        }
    }

}
