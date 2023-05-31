package music.recording;

import static check.CheckThat.Condition.*;
import org.junit.jupiter.api.Test;
import check.CheckThat;

public class ArtistStructureTest {
    @Test
    public void fieldName() {
        CheckThat.theClass("music.recording.Artist")
            .thatIs(FULLY_IMPLEMENTED, INSTANCE_LEVEL, VISIBLE_TO_ALL)
            .hasFieldOfType("name", String.class)
                .thatIs(FULLY_IMPLEMENTED, INSTANCE_LEVEL, NOT_MODIFIABLE, VISIBLE_TO_NONE)
                .thatHas(GETTER)
                .thatHasNo(SETTER);
    }

    @Test
    public void fieldLabel() {
        CheckThat.theClass("music.recording.Artist")
            .hasFieldOfType("label", "RecordLabel")
                .thatIs(FULLY_IMPLEMENTED, INSTANCE_LEVEL, NOT_MODIFIABLE, VISIBLE_TO_NONE)
                .thatHas(GETTER)
                .thatHasNo(SETTER);
    }

    @Test
    public void constructor() {
        CheckThat.theClass("music.recording.Artist")
            .hasConstructorWithParams("java.lang.String", "RecordLabel")
                .thatIs(VISIBLE_TO_ALL);
    }

}

