package music.recording;

import static check.CheckThat.Condition.*;
import org.junit.jupiter.api.Test;
import check.CheckThat;

public class RecordLabelStructureTest {
    @Test
    public void fieldName() {
        CheckThat.theClass("music.recording.RecordLabel")
            .thatIs(FULLY_IMPLEMENTED, INSTANCE_LEVEL, VISIBLE_TO_ALL)
            .hasFieldOfType("name", String.class)
                .thatIs(FULLY_IMPLEMENTED, INSTANCE_LEVEL, NOT_MODIFIABLE, VISIBLE_TO_NONE)
                .thatHas(GETTER)
                .thatHasNo(SETTER);
    }

    @Test
    public void fieldCash() {
        CheckThat.theClass("music.recording.RecordLabel")
            .hasFieldOfType("cash", int.class)
                .thatIs(FULLY_IMPLEMENTED, INSTANCE_LEVEL, MODIFIABLE, VISIBLE_TO_NONE)
                .thatHas(GETTER)
                .thatHasNo(SETTER);
    }

    @Test
    public void constructor() {
        CheckThat.theClass("music.recording.RecordLabel")
            .hasConstructorWithParams(String.class, int.class)
                .thatIs(VISIBLE_TO_ALL);
    }

    @Test
    public void methodGotIncome() {
        CheckThat.theClass("music.recording.RecordLabel")
            .hasMethodWithParams("gotIncome", int.class)
                .thatIs(FULLY_IMPLEMENTED, INSTANCE_LEVEL, VISIBLE_TO_ALL)
                .thatReturnsNothing();
    }
}
