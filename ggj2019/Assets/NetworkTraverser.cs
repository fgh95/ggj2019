using System.Collections.Generic;
using UnityEngine;

public class NetworkTraverser : MonoBehaviour
{
    // Define the nodes in each line in "forward" order (South and East)

    private List<int> line1 = new List<int>
     {12,11,7,2};
    private List<int> line2 = new List<int>
     {1,2,3,4,5};
    private List<int> line3 = new List<int>
     {2,13};
    private List<int> line4 = new List<int>
     {6,7,8,9};
    private List<int> line5 = new List<int>
     {6,7,8,10};
    private List<int> curr_line = new List<int>(); // Set the desired links

    void Start()
    {

    }

    public int getNextStop(int line, int direction, int node, int stops)
    {
        // List<List<int>> lines = new List<List<int>>();
        // 1. Pick current line
        switch (line)
        {
            case 1:
                curr_line = line1;
                break;
            case 2:
                curr_line = line2;
                break;
            case 3:
                curr_line = line3;
                break;
            case 4:
                curr_line = line4;
                break;
            case 5:
                curr_line = line5;
                break;
        }

        // 2. Find the index of your node in that line
        int idx = curr_line.FindIndex(x => x == node);
        // 3. Find the new node depending on your direction and number of stops
        int new_idx = idx + direction * stops;
        if(new_idx > curr_line.Count - 1){
        	new_idx = curr_line.Count - 1;
        }
        if(new_idx < 0){
        	new_idx = 0;
        }
        int new_node = curr_line[new_idx];
        return (new_node);
    }

    void Update()
    {

    }
}