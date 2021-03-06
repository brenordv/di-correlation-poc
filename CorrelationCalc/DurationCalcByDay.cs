using System;
using System.Collections.Generic;
using System.Linq;

namespace CorrelationCalc
{
    public static class DurationCalcByDay
    {
        public static bool RunTests()
        {
            var result1 = Test01();
            var result2 = Test02();
            var result3 = Test03();
            var result4 = Test04();
            var result5 = Test05();
            var result6 = Test06();
            var result7 = Test07();
            var result8 = Test08();

            var checkResults = new List<bool>
            {
                CheckResult(result1, TestExpected01()),
                CheckResult(result2, TestExpected02()),
                CheckResult(result3, TestExpected03()),
                CheckResult(result4, TestExpected04()),
                CheckResult(result5, TestExpected05()),
                CheckResult(result6, TestExpected06()),
                CheckResult(result7, TestExpected07()),
                CheckResult(result8, TestExpected08()),
            };
            return checkResults.All(s => s);
        }

        private static bool CheckResult(List<Range> result, List<Range> expected)
        {
            return expected.All(a => result.SingleOrDefault(s => s.Start == a.Start && s.End == a.End) != null);
        }

        /// <summary>
        ///     Coisas que estao no mesmo dia ... 
        /// </summary>
        private static List<Range> Test01()
        {
            // lista bruta - ordenada por start + duracao DESC
            var unavailabilityListByDay = new List<Range>
            {
                new Range
                {
                    Start = new DateTime(2021, 7, 12, 9, 0, 0, 0),
                    End = new DateTime(2021, 7, 12, 11, 0, 0, 0),
                },
                new Range
                {
                    Start = new DateTime(2021, 7, 12, 10, 0, 0, 0),
                    End = new DateTime(2021, 7, 12, 16, 0, 0, 0),
                },
                new Range
                {
                    Start = new DateTime(2021, 7, 12, 10, 0, 0, 0),
                    End = new DateTime(2021, 7, 12, 15, 0, 0, 0),
                },
                new Range
                {
                    Start = new DateTime(2021, 7, 12, 10, 0, 0, 0),
                    End = new DateTime(2021, 7, 12, 12, 0, 0, 0),
                }
            };

            return CalculationAcme(unavailabilityListByDay);
        }

        private static List<Range> TestExpected01()
        {
            return new List<Range>
            {
                new Range
                {
                    Start = new DateTime(2021, 7, 12, 9, 0, 0, 0),
                    End = new DateTime(2021, 7, 12, 11, 0, 0, 0)
                },
                new Range
                {
                    Start = new DateTime(2021, 7, 12, 11, 0, 0, 0),
                    End = new DateTime(2021, 7, 12, 16, 0, 0, 0)
                },
            };
        }

        /// <summary>
        ///     
        /// </summary>
        /// <returns></returns>
        private static List<Range> Test02()
        {
            // lista bruta - ordenada por start + duracao DESC
            var unavailabilityListByDay = new List<Range>
            {
                new Range
                {
                    Start = new DateTime(2021, 7, 12, 9, 0, 0, 0),
                    End = new DateTime(2021, 7, 12, 11, 0, 0, 0),
                },
                new Range
                {
                    Start = new DateTime(2021, 7, 12, 10, 0, 0, 0),
                    End = new DateTime(2021, 7, 12, 12, 0, 0, 0),
                },
                new Range
                {
                    Start = new DateTime(2021, 7, 12, 14, 0, 0, 0),
                    End = new DateTime(2021, 7, 12, 15, 0, 0, 0),
                }
            };

            return CalculationAcme(unavailabilityListByDay);
        }

        private static List<Range> TestExpected02()
        {
            return new List<Range>
            {
                new Range
                {
                    Start = new DateTime(2021, 7, 12, 9, 0, 0, 0),
                    End = new DateTime(2021, 7, 12, 11, 0, 0, 0)
                },
                new Range
                {
                    Start = new DateTime(2021, 7, 12, 11, 0, 0, 0),
                    End = new DateTime(2021, 7, 12, 12, 0, 0, 0)
                },
            };
        }

        /// <summary>
        ///     
        /// </summary>
        /// <returns></returns>
        private static List<Range> Test03()
        {
            // lista bruta - ordenada por start + duracao DESC
            var unavailabilityListByDay = new List<Range>
            {
                new Range
                {
                    Start = new DateTime(2021, 7, 12, 9, 0, 0, 0),
                    End = new DateTime(2021, 7, 12, 11, 0, 0, 0),
                },
                new Range
                {
                    Start = new DateTime(2021, 7, 12, 9, 0, 0, 0),
                    End = new DateTime(2021, 7, 12, 11, 0, 0, 0),
                },
                new Range
                {
                    Start = new DateTime(2021, 7, 12, 9, 15, 0, 0),
                    End = new DateTime(2021, 7, 12, 12, 3, 0, 0),
                },
                new Range
                {
                    Start = new DateTime(2021, 7, 12, 10, 0, 0, 0),
                    End = new DateTime(2021, 7, 12, 12, 0, 0, 0),
                },
                new Range
                {
                    Start = new DateTime(2021, 7, 12, 14, 0, 0, 0),
                    End = new DateTime(2021, 7, 12, 15, 0, 0, 0),
                }
            };

            return CalculationAcme(unavailabilityListByDay);
        }

        private static List<Range> TestExpected03()
        {
            return new List<Range>
            {
                new Range
                {
                    Start = new DateTime(2021, 7, 12, 9, 0, 0, 0),
                    End = new DateTime(2021, 7, 12, 11, 0, 0, 0)
                },
                new Range
                {
                    Start = new DateTime(2021, 7, 12, 11, 0, 0, 0),
                    End = new DateTime(2021, 7, 12, 12, 3, 0, 0)
                },
                new Range
                {
                    Start = new DateTime(2021, 7, 12, 14, 0, 0, 0),
                    End = new DateTime(2021, 7, 12, 15, 0, 0, 0)
                },
            };
        }

        /// <summary>
        ///     
        /// </summary>
        /// <returns></returns>
        private static List<Range> Test04()
        {
            // lista bruta - ordenada por start + duracao DESC
            var unavailabilityListByDay = new List<Range>
            {
                new Range
                {
                    Start = new DateTime(2021, 7, 12, 9, 0, 0, 0),
                    End = new DateTime(2021, 7, 12, 11, 0, 0, 0),
                },
                new Range
                {
                    Start = new DateTime(2021, 7, 12, 9, 0, 0, 0),
                    End = new DateTime(2021, 7, 12, 11, 0, 0, 0),
                },
                new Range
                {
                    Start = new DateTime(2021, 7, 12, 9, 15, 0, 0),
                    End = new DateTime(2021, 7, 12, 12, 3, 0, 0),
                },
                new Range
                {
                    Start = new DateTime(2021, 7, 12, 10, 0, 0, 0),
                    End = new DateTime(2021, 7, 12, 12, 0, 0, 0),
                },
                new Range
                {
                    Start = new DateTime(2021, 7, 12, 11, 15, 0, 0),
                    End = new DateTime(2021, 7, 12, 12, 4, 0, 0),
                },
                new Range
                {
                    Start = new DateTime(2021, 7, 12, 14, 0, 0, 0),
                    End = new DateTime(2021, 7, 12, 15, 0, 0, 0),
                }
            };

            return CalculationAcme(unavailabilityListByDay);
        }

        private static List<Range> TestExpected04()
        {
            return new List<Range>
            {
                new Range
                {
                    Start = new DateTime(2021, 7, 12, 9, 0, 0, 0),
                    End = new DateTime(2021, 7, 12, 11, 0, 0, 0)
                },
                new Range
                {
                    Start = new DateTime(2021, 7, 12, 11, 0, 0, 0),
                    End = new DateTime(2021, 7, 12, 12, 3, 0, 0)
                },
                new Range
                {
                    Start = new DateTime(2021, 7, 12, 12, 3, 0, 0),
                    End = new DateTime(2021, 7, 12, 12, 4, 0, 0)
                },
                new Range
                {
                    Start = new DateTime(2021, 7, 12, 14, 0, 0, 0),
                    End = new DateTime(2021, 7, 12, 15, 0, 0, 0)
                },
            };
        }

        /// <summary>
        ///     
        /// </summary>
        /// <returns></returns>
        private static List<Range> Test05()
        {
            // lista bruta - ordenada por start + duracao DESC
            var unavailabilityListByDay = new List<Range>
            {
                new Range
                {
                    Start = new DateTime(2021, 7, 12, 0, 0, 0, 0),
                    End = new DateTime(2021, 7, 12, 23, 59, 0, 0),
                },
                new Range
                {
                    Start = new DateTime(2021, 7, 12, 9, 0, 0, 0),
                    End = new DateTime(2021, 7, 12, 11, 0, 0, 0),
                },
                new Range
                {
                    Start = new DateTime(2021, 7, 12, 9, 15, 0, 0),
                    End = new DateTime(2021, 7, 12, 12, 3, 0, 0),
                },
                new Range
                {
                    Start = new DateTime(2021, 7, 12, 10, 0, 0, 0),
                    End = new DateTime(2021, 7, 12, 12, 0, 0, 0),
                },
                new Range
                {
                    Start = new DateTime(2021, 7, 12, 11, 15, 0, 0),
                    End = new DateTime(2021, 7, 12, 12, 4, 0, 0),
                },
                new Range
                {
                    Start = new DateTime(2021, 7, 12, 14, 0, 0, 0),
                    End = new DateTime(2021, 7, 12, 15, 0, 0, 0),
                }
            };

            return CalculationAcme(unavailabilityListByDay);
        }

        private static List<Range> TestExpected05()
        {
            return new List<Range>
            {
                new Range
                {
                    Start = new DateTime(2021, 7, 12, 0, 0, 0, 0),
                    End = new DateTime(2021, 7, 12, 23, 59, 0, 0)
                }
            };
        }

        /// <summary>
        ///     
        /// </summary>
        /// <returns></returns>
        private static List<Range> Test06()
        {
            // lista bruta - ordenada por start + duracao DESC
            var unavailabilityListByDay = new List<Range>
            {
                new Range
                {
                    Start = new DateTime(2021, 7, 12, 9, 0, 0, 0),
                    End = new DateTime(2021, 7, 12, 15, 0, 0, 0),
                },
                new Range
                {
                    Start = new DateTime(2021, 7, 12, 9, 0, 0, 0),
                    End = new DateTime(2021, 7, 12, 11, 0, 0, 0),
                },

                new Range
                {
                    Start = new DateTime(2021, 7, 12, 11, 30, 0, 0),
                    End = new DateTime(2021, 7, 12, 15, 0, 0, 0),
                }
            };

            return CalculationAcme(unavailabilityListByDay);
        }

        private static List<Range> TestExpected06()
        {
            return new List<Range>
            {
                new Range
                {
                    Start = new DateTime(2021, 7, 12, 9, 0, 0, 0),
                    End = new DateTime(2021, 7, 12, 15, 0, 0, 0),
                }
            };
        }

        /// <summary>
        ///     
        /// </summary>
        /// <returns></returns>
        private static List<Range> Test07()
        {
            // lista bruta - ordenada por start + duracao DESC
            var unavailabilityListByDay = new List<Range>
            {
                new Range
                {
                    Start = new DateTime(2021, 7, 12, 9, 0, 0, 0),
                    End = new DateTime(2021, 7, 12, 15, 0, 0, 0),
                },
                new Range
                {
                    Start = new DateTime(2021, 7, 12, 9, 0, 0, 0),
                    End = new DateTime(2021, 7, 12, 15, 0, 0, 0),
                },
            };

            return CalculationAcme(unavailabilityListByDay);
        }

        private static List<Range> TestExpected07()
        {
            return new List<Range>
            {
                new Range
                {
                    Start = new DateTime(2021, 7, 12, 9, 0, 0, 0),
                    End = new DateTime(2021, 7, 12, 15, 0, 0, 0),
                }
            };
        }

        /// <summary>
        ///     
        /// </summary>
        /// <returns></returns>
        private static List<Range> Test08()
        {
            // lista bruta - ordenada por start + duracao DESC
            var unavailabilityListByDay = new List<Range>
            {
                new Range
                {
                    Start = new DateTime(2021, 7, 12, 9, 0, 0, 0),
                    End = new DateTime(2021, 7, 12, 11, 0, 0, 0),
                }
            };

            return CalculationAcme(unavailabilityListByDay);
        }

        private static List<Range> TestExpected08()
        {
            return new List<Range>
            {
                new Range
                {
                    Start = new DateTime(2021, 7, 12, 9, 0, 0, 0),
                    End = new DateTime(2021, 7, 12, 11, 0, 0, 0),
                }
            };
        }

        private static List<Range> CalculationAcme(List<Range> unavailabilityListByDay)
        {
            //lista processada e/ou calculados
            var results = new List<Range>();

            //pra garantir que as listas estao bonitinhas.
            unavailabilityListByDay = unavailabilityListByDay
                .OrderBy(o => o.Start)
                .ThenByDescending(o => o.Duration)
                .ToList();


            foreach (var range in unavailabilityListByDay)
            {
                if (results.Any(a => a.Start == range.Start && a.End == range.End))
                    continue;

                /*
                 * Range:   10:00 -> 13:00
                 * Results: 09:00 -> 12:00
                 *
                 * Range:   11:00 -> 15:00
                 * Results: 09:00 -> 12:00
                 */
                var intersectStartRange = results.FirstOrDefault(
                    w => w.Start <= range.Start &&
                         w.End > range.Start // Lista! Tem alguem que começa antes de Start e termina depois de Start?
                );

                /*
                 * Range:   10:00 -> 15:00
                 * Results: 11:00 -> 16:00
                 *
                 * Range:   11:00 -> 15:00
                 * Results: 11:00 -> 16:00
                 *
                 * Range:   11:00 -> 15:00
                 * Results: 12:00 -> 16:00
                 *
                 * Range:   09:00 -> 11:00
                 * Results: 09:00 -> 11:00
                 */
                var intersectEndRange = results.FirstOrDefault(
                    w => w.Start <= range.End &&
                         w.End > range.End // Lista! Tem alguem que começa antes de End e termina depois de End?
                );

                // Se nao tem nenhum dos casos, entao esse <range> é realmente novo. 
                if (intersectStartRange == null && intersectEndRange == null)
                {
                    results.Add(range);
                    continue;
                }

                if (intersectStartRange != null && intersectEndRange != null)
                {
                    if (intersectStartRange == intersectEndRange)
                    {
                        // Se for o mesmo objeto, entao esse <range> já está compreendido dentro do intersect (dentro do result).
                        continue;
                    }

                    if (intersectStartRange.End == intersectEndRange.Start)
                    {
                        //se eles forem iguais, range está completamente dentro destes dois registros
                        //os dois registros estao coladinhos
                        continue;
                    }

                    // Adiciona nos resultados apenas a diferença entre os dois registros.
                    // Cobrindo só o buraco que ficou entre os dois registros.
                    results.Add(new Range
                    {
                        Start = intersectStartRange.End,
                        End = intersectEndRange.Start
                    });
                    continue;
                }

                if (intersectStartRange != null)
                {
                    //Se o meu range estiver 100% dentro do intesectStart, entao passa para o próximo.
                    if (range.Start >= intersectStartRange.Start && range.End <= intersectStartRange.End)
                        continue;

                    // O intersectEnd é nulo, entao devo começar a partir do End do intersectStart até o End do range,
                    // pois ele nao estava coberto na lista de resultados. 
                    results.Add(new Range
                    {
                        Start = intersectStartRange.End,
                        End = range.End
                    });
                    continue;
                }

                //Se o meu range estiver 100% dentro do intersectEnd, entao passa para o próximo.
                if (range.Start >= intersectEndRange.Start && range.End <= intersectEndRange.End)
                    continue;
                
                // Neste ponto, o range deve ser adicionado desde o seu Start até o start do intersectEnd, pois nao 
                // foi encontrado um intersectStart para ele.
                results.Add(new Range
                {
                    Start = range.Start,
                    End = intersectEndRange.Start
                });
            }

            return results;
        }
    }
}