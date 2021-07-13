using System;
using System.Collections.Generic;
using System.Linq;

namespace CorrelationCalc
{
    public static class DateTimeExt
    {
        public static bool IsSameDay(this DateTime dt, DateTime dateTime)
        {
            return dt.Date == dateTime.Date;
        }
    }

    public static class SplitDateTimeByDay
    {
        public static bool RunTests()
        {
            var targetDay = new DateTime(2021, 7, 13, 0, 0, 0, 0);

            var result01 = Test01(targetDay);
            var result02 = Test02(targetDay.AddDays(-10));
            var result03 = Test03(targetDay.AddDays(10));
            var result04 = Test04(targetDay);
            var result05 = Test05(targetDay);
            var result06 = Test06(targetDay);

            var checkResults = new List<bool>
            {
                TestExpected01(result01),
                TestExpected02(result02), 
                TestExpected03(result03), 
                TestExpected04(result04),
                TestExpected05(result05),
                TestExpected06(result06)
            };
            
            return checkResults.All(a => a);
        }

        private static Range Test01(DateTime targetDay)
        {
            return SplitDateTime(targetDay, new Range
            {
                Start = new DateTime(2021, 7, 13, 9, 0, 0, 0),
                End = new DateTime(2021, 7, 13, 11, 0, 0, 0)
            });
        }

        public static bool TestExpected01(Range range)
        {
            var r = new Range
            {
                Start = new DateTime(2021, 7, 13, 9, 0, 0, 0),
                End = new DateTime(2021, 7, 13, 11, 0, 0, 0)
            };

            return r.Start == range.Start && r.End == range.End;
        }

        private static Range Test02(DateTime targetDay)
        {
            return SplitDateTime(targetDay, new Range
            {
                Start = new DateTime(2021, 7, 13, 9, 0, 0, 0),
                End = new DateTime(2021, 7, 13, 11, 0, 0, 0)
            });
        }

        public static bool TestExpected02(Range range)
        {
            return range == null;
        }

        private static Range Test03(DateTime targetDay)
        {
            return SplitDateTime(targetDay, new Range
            {
                Start = new DateTime(2021, 7, 13, 9, 0, 0, 0),
                End = new DateTime(2021, 7, 13, 11, 0, 0, 0)
            });
        }

        private static bool TestExpected03(Range range)
        {
            return range == null;
        }

        private static Range Test04(DateTime targetDay)
        {
            return SplitDateTime(targetDay, new Range
            {
                Start = new DateTime(2021, 7, 12, 9, 0, 0, 0),
                End = new DateTime(2021, 7, 14, 11, 0, 0, 0)
            });
        }

        private static bool TestExpected04(Range range)
        {
            var x = new Range
            {
                Start = new DateTime(2021, 7, 13, 0, 0, 0, 0),
                End = new DateTime(2021, 7, 13, 23, 59, 0, 0)
            };

            return x.Start == range.Start && x.End == range.End;
        }
        
        private static Range Test05(DateTime targetDay)
        {
            return SplitDateTime(targetDay, new Range
            {
                Start = new DateTime(targetDay.Year, targetDay.Month, targetDay.Day, 9, 0, 0, 0),
                End = targetDay.AddDays(12)
            });
        }

        private static bool TestExpected05(Range range)
        {
            var x = new Range
            {
                Start = new DateTime(2021, 7, 13, 9, 0, 0, 0),
                End = new DateTime(2021, 7, 13, 23, 59, 0, 0)
            };

            return x.Start == range.Start && x.End == range.End;
        }
        
        private static Range Test06(DateTime targetDay)
        {
            return SplitDateTime(targetDay, new Range
            {
                Start = targetDay.AddDays(-1),  
                End = new DateTime(targetDay.Year, targetDay.Month, targetDay.Day, 11, 0, 0, 0)
            });
        }

        private static bool TestExpected06(Range range)
        {
            var x = new Range
            {
                Start = new DateTime(2021, 7, 13, 0, 0, 0, 0),
                End = new DateTime(2021, 7, 13, 11, 0, 0, 0)
            };

            return x.Start == range.Start && x.End == range.End;
        }
        
        private static Range SplitDateTime(DateTime targetDay, Range range)
        {
            if (targetDay.Date < range.Start.Date || targetDay.Date > range.End.Date)
            {
                Console.WriteLine("!!!!!!!!!!!!!!!!! [--DEU RUIM--] !!!!!!!!!!!!!!!!!!!!!!");
                return null;
            }

            if (targetDay.IsSameDay(range.Start) && range.Start.IsSameDay(range.End))
            {
                return range;
            }

            if (!targetDay.IsSameDay(range.Start) && !targetDay.IsSameDay(range.End))
            {
                return new Range
                {
                    Start = new DateTime(targetDay.Year, targetDay.Month, targetDay.Day, 0, 0, 0, 0),
                    End = new DateTime(targetDay.Year, targetDay.Month, targetDay.Day, 23, 59, 0, 0)
                };
            }

            if (targetDay.IsSameDay(range.Start))
            {
                return new Range
                {
                    Start = range.Start,
                    End = new DateTime(targetDay.Year, targetDay.Month, targetDay.Day, 23, 59, 0, 0)
                };
            }

            return new Range
            {
                Start = new DateTime(targetDay.Year, targetDay.Month, targetDay.Day, 0, 0, 0, 0),
                End = range.End
            };
        }
    }
}