package music.fan;

import static check.CheckThat.Condition.*;
import org.junit.jupiter.api.Test;
import check.CheckThat;

public class FanStructureTest {
    @Test
    public void fieldName() {
        CheckThat.theClass("music.fan.Fan")
            .thatIs(FULLY_IMPLEMENTED, INSTANCE_LEVEL, VISIBLE_TO_ALL)
            .hasFieldOfType("name", String.class)
                .thatIs(FULLY_IMPLEMENTED, INSTANCE_LEVEL, NOT_MODIFIABLE, VISIBLE_TO_NONE)
                .thatHas(GETTER)
                .thatHasNo(SETTER);
    }

    @Test
    public void fieldFavourite() {
        CheckThat.theClass("music.fan.Fan")
            .hasFieldOfType("favourite", "music.recording.Artist")
                .thatIs(FULLY_IMPLEMENTED, INSTANCE_LEVEL, NOT_MODIFIABLE, VISIBLE_TO_NONE)
                .thatHas(GETTER)
                .thatHasNo(SETTER);
    }

    @Test
    public void fieldMoneySpent() {
        CheckThat.theClass("music.fan.Fan")
            .hasFieldOfType("moneySpent", int.class)
                .thatIs(FULLY_IMPLEMENTED, INSTANCE_LEVEL, MODIFIABLE, VISIBLE_TO_NONE)
                .thatHas(GETTER)
                .thatHasNo(SETTER);
    }

    @Test
    public void constructor() {
        CheckThat.theClass("music.fan.Fan")
            .hasConstructorWithParams("java.lang.String", "music.recording.Artist")
                .thatIs(VISIBLE_TO_ALL);
    }

    @Test
    public void methodBuyMerchandise() {
        CheckThat.theClass("music.fan.Fan")
            .hasMethodWithParams("buyMerchandise", "int", "vararg of Fan")
                .thatIs(FULLY_IMPLEMENTED, INSTANCE_LEVEL, VISIBLE_TO_ALL)
                .thatReturns(int.class);
    }

    @Test
    public void methodFavesAtSameLabel() {
        CheckThat.theClass("music.fan.Fan")
            .hasMethodWithParams("favesAtSameLabel", "Fan")
                .thatIs(FULLY_IMPLEMENTED, INSTANCE_LEVEL, VISIBLE_TO_ALL)
                .thatReturns(boolean.class);
    }

    @Test
    public void methodToString1() {
        CheckThat.theClass("music.fan.Fan")
            .hasMethodWithNoParams("toString1")
                .thatIs(FULLY_IMPLEMENTED, INSTANCE_LEVEL, VISIBLE_TO_ALL)
                .thatReturns(String.class);
    }

    @Test
    public void methodToString2() {
        CheckThat.theClass("music.fan.Fan")
            .hasMethodWithNoParams("toString2")
                .thatIs(FULLY_IMPLEMENTED, INSTANCE_LEVEL, VISIBLE_TO_ALL)
                .thatReturns(String.class);
    }

    @Test
    public void methodToString3() {
        CheckThat.theClass("music.fan.Fan")
            .hasMethodWithNoParams("toString3")
                .thatIs(FULLY_IMPLEMENTED, INSTANCE_LEVEL, VISIBLE_TO_ALL)
                .thatReturns(String.class);
    }

}

