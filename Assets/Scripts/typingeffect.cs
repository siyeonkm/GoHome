using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class typingeffect : MonoBehaviour
{

    public Text tx;
    private string m_text = "오늘도 무사히 퇴근을 했다.12월 24일 크리스마스 이브가 금요일과 겹칠게 뭐람... 평소보다 차가 두배로 있는 듯 하다.";
    
    void Start()
    {
        StartCoroutine(_typing());
    }

    
IEnumerator _typing()
    {
        yield return new WaitForSeconds(2f);

        for(int i = 0; i <= m_text.Length; i++)
        {
            tx.text = m_text.Substring(0, i);

            
            yield return new WaitForSeconds(0.15f);
        }
    }
}
