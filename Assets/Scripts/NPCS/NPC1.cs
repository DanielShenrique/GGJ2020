using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC1 : MonoBehaviour
{
    private string text;

    public int numEnemiesInst;
    public int numEnemiesDefeated;

    private bool canInstantiateEnemies;
    private bool defeatTheEnemies;

    [SerializeField]
    private Text txt;

    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private Transform posEnemy;

    private GameController gameController;

    private void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void Start()
    {
        text = "Vá e derrote os inimigos";

        numEnemiesInst = 3;
        numEnemiesDefeated = 0;

        defeatTheEnemies = false;
    }

    private void Update()
    {
        if (canInstantiateEnemies)
        {
            InstantiateEnemies();
        }

        EnemiesDefeated();
    }

    private void InstantiateEnemies()
    {
        if(numEnemiesInst >= 1)
        {
            Instantiate(enemy, posEnemy);
            numEnemiesInst--;
        }
    }

    private void EnemiesDefeated()
    { 
        if(numEnemiesDefeated >= 3)
        {
            canInstantiateEnemies = false;
            defeatTheEnemies = true;
            txt.text = null;
            gameController.canBugGame = true;
        }
    
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals("Player"))
        {
            if(defeatTheEnemies == false)
            {
                txt.text = text;
                canInstantiateEnemies = true; 
            }
        }
    }
}
