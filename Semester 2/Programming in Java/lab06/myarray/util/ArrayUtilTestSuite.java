package myarray.util;

import org.junit.platform.suite.api.SelectClasses;
import org.junit.platform.suite.api.Suite;

//import myarray.util.ArrayUtilTest;

@Suite
@SelectClasses({
	ArrayUtilStructureTest.class,
	ArrayUtilTest.class
})
public class ArrayUtilTestSuite {}

