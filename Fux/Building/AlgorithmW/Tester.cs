﻿using static Fux.Building.AlgorithmW.HelperFunctions;

#pragma warning disable IDE1006 // Naming Styles
#pragma warning disable CS0162 // Unreachable code detected

namespace Fux.Building.AlgorithmW
{
    public static class Tester
    {
        public static void Run()
        {
            test(app(app(var("+"), integer(1)), integer(2)));

            test(
                let("n", floating(0),
                    iff(app(var("lt"), var("n"), integer(0)),
                        app(var("-"), var("n")),
                        var("n")
                )));

            return;

            test(iff(lit(true), integer(4), floating(4.0)));


            test(integer(5));
            test(lit("hello"));
            test(lit(true));
            test(app(app(var("+"), integer(1)), integer(2)));
            test(let("x", integer(4), let("y", lit("5"), app(app(var("+"), var("x")), var("y")))));
            test(app(app(var("+"), lit(true)), lit(false)));
            test(app(var("-"), integer(5)));
            test(app(var("-"), lit("test")));
            test(let("id", abs("x", var("x")), var("id")));
            test(let("five", abs("x", integer(5)), var("five")));
            test(let("id", abs("x", var("x")), app(var("id"), var("id"))));
            test(let("id",
                abs("x", let("y", var("x"), var("y"))),
                app(var("id"), var("id"))));
            test(let("id",
                abs("x", let("y", var("x"), var("y"))),
                app(app(var("id"), var("id")), integer(2))));
            test(let("id", abs("x", app(var("x"), var("x"))), var("id")));
            test(abs("m",
                let("y", var("m"), let("x", app(var("y"), lit(true)), var("x")))));
            test(app(integer(2), integer(2)));
            test(abs("a",
                     let("x",
                          abs("b",
                              let("y", abs("c", app(var("a"), integer(1))), app(var("y"), integer(2)))),
                          app(var("x"), integer(3)))));
            test(app(abs("a",
                         let("x",
                              abs("b",
                                  let("y", abs("c", app(var("a"), integer(1))), app(var("y"), integer(2)))),
                              app(var("x"), integer(3)))),
                     abs("x", var("x"))));

            test(abs("f",
                     app(abs("x", app(var("f"), app(var("x"), var("x")))),
                         abs("x", app(var("f"), app(var("x"), var("x")))))));

            test(app(abs("f",
                         app(abs("x", app(var("f"), app(var("x"), var("x")))),
                             abs("x", app(var("f"), app(var("x"), var("x")))))),
                     abs("x", var("x"))));
            test(abs("x", abs("y", var("x")))); // true
            test(abs("x", abs("y", var("y")))); // false
            test(let("id",
                      abs("x", var("x")),
                      let("eat2",
                           abs("x", abs("y", lit("foo"))),
                           app(app(var("eat2"), app(var("id"), integer(1))),
                               app(var("id"), lit(true))))));
            test(let("+",
                      abs("x", app(var("+"), var("x"))),
                      app(app(var("+"), integer(1)), integer(2))));
            test(app(abs("x", app(var("x"), var("x"))),
                     abs("x", app(var("x"), var("x")))));
            test(abs("x", app(var("x"), var("x"))));
            test(app(abs("x", app(var("x"), var("x"))), abs("x", var("x"))));

            // the output on this case is correct but nondeterministic because of the random iteration
            // order of Rust's HashMaps and HashSets
            test(let("zero",
                      abs("f", abs("x", var("x"))),
                      let("succ",
                           abs("n",
                               abs("f",
                                   abs("x", app(var("f"), app(app(var("n"), var("f")), var("x")))))),
                           app(var("succ"),
                               app(var("succ"),
                                   app(var("succ"),
                                       app(var("succ"),
                                           app(var("succ"),
                                               app(var("succ"),
                                                   app(var("succ"),
                                                       app(var("succ"),
                                                           app(var("succ"), var("zero")))))))))))));

            // this case produces an incredibly large type
            test(let("zero",
                      abs("f", abs("x", var("x"))),
                      let("succ",
                           abs("n",
                               abs("f",
                                   abs("x", app(var("f"), app(var("n"), app(var("f"), var("x"))))))),
                           app(var("succ"),
                               app(var("succ"),
                                   app(var("succ"),
                                       app(var("succ"),
                                           app(var("succ"),
                                               app(var("succ"),
                                                   app(var("succ"),
                                                       app(var("succ"),
                                                           app(var("succ"), var("zero")))))))))))));
        }

        private static void test(Expression expression)
        {
            var typeInferrer = new TypeInferrer();
            var typeEnvironment = typeInferrer.GetDefaultTypeEnvironment();
            var typeVarGenerator = new TypeVarGenerator();

            Console.WriteLine($"INPUT: {expression}");
            var result = typeInferrer.Run(expression, typeEnvironment, typeVarGenerator);
            switch (result)
            {
                case (InferredType type, _):
                    Console.WriteLine($"OUTPUT: {type}");
                    break;
                case (_, TypeInferenceError(string error)):
                    Console.WriteLine($"FAIL: {error}");
                    break;
            }
            Console.WriteLine();
        }
    }
}
