package worker.schedule;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;

public class WorkerSchedule
{
    private HashMap<Integer, HashSet<String>> weektoWorkers;

    public void add(int week, HashSet<String> workers)
    {
        if (!weektoWorkers.containsKey(week - 1))
        {
            weektoWorkers.put(week - 1, new HashSet<String>());
        }

        weektoWorkers.get(week - 1).addAll(workers);
    }

    public void add(HashSet<Integer> weeks, ArrayList<String> workers)
    {
        HashSet<String> workerSet = new HashSet<String>(workers);
        for (int elem : weeks) 
        {
            add(elem,  workerSet);    
        }
    }

    public boolean isWorkingOnWeek(String worker, int week)
    {
        return weektoWorkers.get(week - 1).contains(worker);
    }

    public HashSet<Integer> getWorkWeeks(String worker)
    {
        HashSet<Integer> weeks = new HashSet<Integer>();

        for (Map.Entry<Integer, HashSet<String>> entry : weektoWorkers.entrySet()) 
        {
            if (entry.getValue().contains(worker))
            {
                weeks.add(entry.getKey() + 1);
            }
        }

        return weeks;
    }
}