using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager Instance { get; private set; }

    public bool isFirstTurn = true;

    public List<flip_Card> AllFlipCards;
    public List<Sprite> allsprite;

    private List<flip_Card> openedCards = new List<flip_Card>();
    private bool isChecking = false;

    private int totalMatch = 0;

    public flip_Card firstCard;
    public flip_Card secondCard;

    public List<Sprite> levelSprites;

    public Transform lvlone;
    public GameObject leveOne;
    public GridLayoutGroup layoutGroup;

    public int level = 2;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        //InlizedGame();
    }

    public void InlizedGame()
    {
        while (levelSprites.Count != level * 2)
        {
            int random = Random.Range(0, allsprite.Count);

            if (!levelSprites.Contains(allsprite[random]))
            {
                levelSprites.Add(allsprite[random]);
                levelSprites.Add(allsprite[random]);
            }
        }

        //levelSprites = SuffleList(levelSprites);
        ListSuffle();
        AssignImage();
    }

    public List<Sprite> SuffleList(List<Sprite> suffList)
    {
        for (int i = 0; i < suffList.Count; i++)
        {
            int random = Random.Range(0, suffList.Count);
            Sprite temp = suffList[random];
            suffList[random] = suffList[i];
            suffList[i] = temp;
        }
        return suffList;
    }

    public void ListSuffle()
    {
        for (int i = 0; i < levelSprites.Count; i++)
        {
            int random = Random.Range(0, levelSprites.Count);
            Sprite temp = levelSprites[random];
            levelSprites[random] = levelSprites[i];
            levelSprites[i] = temp;
        }
    }

    public void AssignImage()
    {
        for (int i = 0; i < AllFlipCards.Count; i++)
        {
            AllFlipCards[i].newSprite = levelSprites[i];
        }
    }

    public void ClickCard(int index)
    {
        if (isChecking || openedCards.Contains(AllFlipCards[index])) return;

        AllFlipCards[index].button.interactable = false;
        AllFlipCards[index].FlipOpen();
        openedCards.Add(AllFlipCards[index]);

        if (openedCards.Count == 2)
        {
            StartCoroutine(CheckCardWin());
        }
        else if (openedCards.Count > 2)
        {
            // If somehow 3 cards are open (failsafe), close first 2 and open the 3rd properly
            for (int i = 0; i < openedCards.Count - 1; i++)
            {
                openedCards[i].FlipBack();
                openedCards[i].button.interactable = true;
            }

            flip_Card latestCard = openedCards[openedCards.Count - 1];
            openedCards.Clear();
            openedCards.Add(latestCard);
        }
    }

    /*public void ClickCard(int index)
    {
        AllFlipCards[index].button.interactable = false;
        AllFlipCards[index].FlipOpen();

        if (isFirstTurn)
        {
            firstCard = AllFlipCards[index];
        }
        else
        {
            secondCard = AllFlipCards[index];
        }

        if (!isFirstTurn)
        {
            StartCoroutine(CheckCardWin());
        }

        isFirstTurn = !isFirstTurn;
    }*/



    public IEnumerator CheckCardWin()
    {
        isChecking = true;
        yield return new WaitForSeconds(0.7f);

        flip_Card first = openedCards[0];
        flip_Card second = openedCards[1];

        if (first.newSprite == second.newSprite)
        {
            first.transform.DOScale(Vector3.zero, 0.3f);
            second.transform.DOScale(Vector3.zero, 0.3f);
            totalMatch++;

            if (totalMatch >= level)
            {
                UiManager.Instance.gamePLay.SetActive(false);
                UiManager.Instance.lvlCompletPanel.SetActive(true);
                UiManager.Instance.lvlCompletPanel.transform.DOScale(Vector3.one, 0.8f);
            }

            openedCards.Clear();
        }
        else
        {
            first.FlipBack();
            second.FlipBack();
            first.button.interactable = true;
            second.button.interactable = true;

            openedCards.Clear();
        }

        isChecking = false;
    }


    /* public IEnumerator CheckCardWin()
     {
         yield return new WaitForSeconds(0.7f);

         if (firstCard.newSprite == secondCard.newSprite)
         {
             firstCard.transform.DOScale(Vector3.zero, 0.3f);
             secondCard.transform.DOScale(Vector3.zero, 0.3f);
             totalMatch++;

             if(totalMatch >= level)
             {
                 UiManager.Instance.gamePLay.SetActive(false);
                 UiManager.Instance.lvlCompletPanel.SetActive(true);
                 UiManager.Instance.lvlCompletPanel.transform.DOScale(Vector3.one, 0.8f);
             }
         }
         else
         {
             firstCard.FlipBack();
             secondCard.FlipBack();

             firstCard.button.interactable = true;
             secondCard.button.interactable = true;
         }

     }  */

    public void OnLevelSelect(int index)
    {
        if (index == 1)
        {
            layoutGroup.cellSize = new Vector2(700, 400);
            layoutGroup.padding.left = 500;
        }
        if (index == 2)
        {
            layoutGroup.cellSize = new Vector2(785, 400);
            layoutGroup.padding.left = 50;
        }
        if (index == 3)
        {
            layoutGroup.cellSize = new Vector2(513, 400);
        }
        if (index == 4)
        {
            layoutGroup.cellSize = new Vector2(377, 400);
        }
        if (index == 5)
        {
            layoutGroup.cellSize = new Vector2(295, 400);
        }
        if (index == 6)
        {
            layoutGroup.cellSize = new Vector2(295, 400);
        }

        for (int i = 0; i < index * 2; i++)
        {
            if (index * 2 >= 10)
            {
                if (i >= 10)
                {
                    return;
                }
            }
            GameObject g = Instantiate(leveOne, lvlone);
            AllFlipCards.Add(g.GetComponent<flip_Card>());

            Button btn = g.GetComponent<Button>();
            int index1 = i;
            btn.onClick.AddListener(() => ClickCard(index1));
        }
        level = index;
        InlizedGame();
    }

}