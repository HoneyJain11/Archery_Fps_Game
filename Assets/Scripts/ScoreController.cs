using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI scoreText;
    private int score = 0;
    public SpwanArrow spwanArrow;
    [SerializeField]
    GameObject winPanel;
    [SerializeField]
    GameObject losePanel;
    [SerializeField]
    Button winCloseButton;
    [SerializeField]
    Button looseCloseButton;


    void Start()
    {
        RefreshUI();
        winCloseButton.onClick.AddListener(delegate { ClosePanel(winPanel); });
        looseCloseButton.onClick.AddListener(delegate { ClosePanel(losePanel); });
    }
    private void OnTriggerEnter (Collider other)
    {
        if(other.gameObject.GetComponent<ShootForce>())
        {
            Debug.Log("Collision Occur");
            
        }
        IncreaseScore(10);
    }
    private void RefreshUI()
    {
        scoreText.text = "Score: " + score;
    }
    public void IncreaseScore(int increment)
    {
        score = score + increment;
        RefreshUI();
        OpenPanel();
    }

    private void OpenPanel()
    {
        if (score >= 50 && spwanArrow.arrowCount >= 7)
        {
            winPanel.SetActive(true);
        }
        else if (spwanArrow.arrowCount < 7)
        {
            losePanel.SetActive(true);
        }
        else
            return;
    }

    private void ClosePanel(GameObject gameObject)
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("GamePlay");
    }
    
}
