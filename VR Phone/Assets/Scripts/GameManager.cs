using System.Collections;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// 定義欄位
    /// </summary>
    [Header("燈光群組")]
    public GameObject grouplight;
    [Header("會動的東西")]
    public Transform something;
    [Header("會動的水桶")]
    public Transform water;
    [Header("喇叭")]
    public AudioSource aud;
    [Header("東西聲音")]
    public AudioClip soundsomething;
    [Header("水桶聲音")]
    public AudioClip soundwater;
    [Header("劍的聲音")]
    public AudioClip soundsword;
    [Header("會動的劍")]
    public Transform sword;
    [Header("劍的拔刀")]
    public AudioClip soundsword_2;

    private int countsword;

  
    public void Looksword()
    {
        countsword++;

        if (countsword == 1)
        {
            aud.PlayOneShot(soundsword, 5);
        }
        else if (countsword == 2)
        {
            aud.PlayOneShot(soundsword_2, 5);
            sword.GetComponent<MeshRenderer>().enabled = false;
            
        }

    }


    /// <summary>
    /// 燈光閃爍
    /// </summary>
    public IEnumerator lightEffect()
    {
        grouplight.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        grouplight.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        grouplight.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        grouplight.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        grouplight.SetActive(false);
        yield return new WaitForSeconds(0.15f);
        grouplight.SetActive(true);
    }
    /// <summary>
    /// 開始移動東西
    /// </summary>
    public void StartMoneSomething() 
    {
        StartCoroutine(Movesomething());
    }
    /// <summary>
    /// 移動東西
    /// </summary>
    /// <returns></returns>
    public IEnumerator Movesomething()
    {
        aud.PlayOneShot(soundsomething, 2.5f);
        
        for (int i = 0; i < 25; i++)
        {
        something.position -= something.forward * 0.1f;
        yield return new WaitForSeconds(0.001f);

        }
        something.GetComponent<CapsuleCollider>().enabled = false;
        //MeshRenderer
    }

    /// <summary>
    /// 開始移動水桶
    /// </summary>
    public void StartMovewater()
    {
        StartCoroutine(Movewater());
    }
    /// <summary>
    /// 移動水桶
    /// </summary>
    /// <returns></returns>
    public IEnumerator Movewater()
    {
        aud.PlayOneShot(soundwater, 2.5f);
        
        for (int i = 0; i < 25; i++)
        {
            water.position -= water.forward * 0.1f;
            yield return new WaitForSeconds(0.001f);

        }
        water.GetComponent<CapsuleCollider>().enabled = false;
        //MeshRenderer
    }



    /// <summary>
    /// 事件開始，只執行一次
    /// </summary>
    private void Start()
    {
        StartCoroutine(lightEffect());
    }
}
