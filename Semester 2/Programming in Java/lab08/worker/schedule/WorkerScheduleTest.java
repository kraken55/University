package worker.schedule;

import static org.junit.Assert.assertFalse;

import java.util.ArrayList;
import java.util.List;

import org.junit.Test;

public class WorkerScheduleTest 
{
    @Test
    public void emptySchedule()
    {
        WorkerSchedule ws = new WorkerSchedule();
        ArrayList<String> as = new ArrayList<>(List.of("w1", "w2", "w3"));
        for (String worker : as)
        {
            for (int i = 0; i < 7; i++)
            {
                assertFalse(ws.isWorkingOnWeek(worker, i));
            }
        }
    }
}
