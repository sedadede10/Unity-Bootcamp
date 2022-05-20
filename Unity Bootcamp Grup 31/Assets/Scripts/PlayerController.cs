using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isMoving;
    private Vector3 originalPos, targetPos;
    private float timeToMove = 0.2f;//gridler arasý geçiþ zamaný
    public GirdiyiAlma inputgirdisi;
    int i;
    bool kontrol = true;
    int durum = 0;

    void Start()
    {
           
    }
    void Update()
    {        
        if(Input.GetKeyDown(KeyCode.F)&& !isMoving)
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
            
            StartCoroutine(MovePlayer(Vector3.up));
            yield return new WaitForSeconds(0.5f);
            i++;
            if(i==tekrar)
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

            StartCoroutine(MovePlayer(Vector3.right));
            yield return new WaitForSeconds(0.5f);
            i++;
            if (i == tekrar)
            {
                kontrol = false;
                
            }
        }
        i = 0;
        kontrol = true;
        durum = durum + 1;
        
    }

    public IEnumerator SolaGitme(int tekrar)
    {
        while (kontrol)
        {

            StartCoroutine(MovePlayer(Vector3.left));
            yield return new WaitForSeconds(0.5f);
            i++;
            if (i == tekrar)
            {
                kontrol = false;
            }
        }
        i = 0;
        kontrol = true;
        durum = durum + 1;
        
    }

    public IEnumerator AsagiGitme(int tekrar)
    {
        while (kontrol)
        {

            StartCoroutine(MovePlayer(Vector3.down));
            yield return new WaitForSeconds(0.5f);
            i++;
            if (i == tekrar)
            {
                kontrol = false;
            }
        }
        i = 0;
        kontrol = true;
        durum = durum + 1;
        
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
            StartCoroutine(AsagiGitme(inputgirdisi.TekrarSayisi_asagi));
        }
        yield return null;
    }

}
