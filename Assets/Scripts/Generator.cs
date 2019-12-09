using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] int amtGenerated = 10;
    [SerializeField] float generationPeriod = 10f;

    float generateCounter;
    
    //Cached reference
    Resource resourceManager;

    Animator animator;

    private void Start()
    {
        generateCounter = generationPeriod;
        resourceManager = FindObjectOfType<Resource>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        generateCounter -= Time.deltaTime;
        if (generateCounter <= 0)
        {
            animator.SetBool("doGenerate", true);
        }
    }

    private void Generate()
    {
        animator.SetBool("doGenerate", false);        
        generateCounter = generationPeriod;
        resourceManager.IncResources(amtGenerated);
    }
}
