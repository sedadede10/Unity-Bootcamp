using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GirdiyiAlma : PlayerController
{
    public InputField Girdi_ileri;//input field icin sabit olusturuldu
    public InputField Girdi_saga;
    public InputField Girdi_sola;
    public InputField Girdi_asagi;
    public InputField girdi_ok;
    
    public int TekrarSayisi_ileri;//inputtan girilen girdiyi almak icin sabit
    public int TekrarSayisi_saga;
    public int TekrarSayisi_sola;
    public int TekrarSayisi_asagi;
    public int okSayisi;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }


    public void ÝleriGirdiyiSabiteEsitleme()
    {
        TekrarSayisi_ileri = int.Parse(Girdi_ileri.text);//input field içerisindeki girdiyi text formatindan int formatina donusturup TekrarSayisi sabitine esitlendi
        
    }
    public void SagaGirdiyiSabiteEsitleme()
    {
        TekrarSayisi_saga = int.Parse(Girdi_saga.text);
    }

    public void SolaGirdiyiSabiteEsitleme()
    {
        TekrarSayisi_sola = int.Parse(Girdi_sola.text);
    }
    public void AsagiGirdiyiSabiteEsitleme()
    {
        TekrarSayisi_asagi = int.Parse(Girdi_asagi.text);
    }
    public void oksayisiniEsitleme()
    {
        okSayisi = int.Parse(girdi_ok.text);
    }
}
