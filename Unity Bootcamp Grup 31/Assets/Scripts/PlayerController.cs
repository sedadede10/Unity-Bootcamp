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

    void Start()
    {
           
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W)&& !isMoving)
        {
            StartCoroutine(ileriGitme(inputgirdisi.TekrarSayisi_ileri));   
        }
        if (Input.GetKey(KeyCode.A) && !isMoving)
        {
            StartCoroutine(SolaGitme(inputgirdisi.TekrarSayisi_sola));
        }
        if (Input.GetKey(KeyCode.D) && !isMoving)
        {
            StartCoroutine(SagaGitme(inputgirdisi.TekrarSayisi_saga));
        }
        if (Input.GetKey(KeyCode.S) && !isMoving)
        {
            StartCoroutine(AsagiGitme(inputgirdisi.TekrarSayisi_asagi));
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
        yield return null;
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
        yield return null;
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
        yield return null;
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
        yield return null;
    }
}
