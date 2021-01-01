using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kociemba;

public class SolveTwoPhase : MonoBehaviour
{
    private CubeState cubeState;
    private ReadCube readCube;
    private bool doOnce = true;

    private void Start()
    {
        cubeState = FindObjectOfType<CubeState>();
        readCube = FindObjectOfType<ReadCube>();
    }

    private void Update()
    {
        if (CubeState.started && doOnce)
        {
            doOnce = false;
            Solver();
        }
    }

    public void Solver()
    {
        readCube.ReadState();

        string moveString = cubeState.GetStateString();

        string info = "";

        //string solution = SearchRunTime.solution(moveString, out info, buildTables: true);
        string solution = Search.solution(moveString, out info);

        List<string> solutionList = StringToList(solution);

        Automate.moveList = solutionList;
    }

    private List<string> StringToList(string solution)
    {
        List<string> solutionList = new List<string>(solution.Split(new string[] { " " }, System.StringSplitOptions.RemoveEmptyEntries));
        return solutionList;
    }
}
