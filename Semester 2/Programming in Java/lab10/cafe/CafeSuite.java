package cafe;

import org.junit.platform.suite.api.SelectClasses;
import org.junit.platform.suite.api.Suite;

@Suite
@SelectClasses({
    BartenderStructureTest.class,
    GuestStructureTest.class,
    AdultStructureTest.class,
    MinorStructureTest.class,
    CafeTest.class
})
public class CafeSuite {}
