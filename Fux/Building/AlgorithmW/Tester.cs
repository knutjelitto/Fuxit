using static Fux.Building.AlgorithmW.TesterHelper;

#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable IDE1006 // Naming Styles
#pragma warning disable CS0162 // Unreachable code detected

namespace Fux.Building.AlgorithmW
{
    public static class Tester
    {
        public static void Run()
        {
            test(app(var("+"), floating(1), floating(2)));
            test(app(var("+"), integer(1), integer(2)));

            test(
                let("n", integer(0),
                    iff(app(var("<"), var("n"), integer(0)),
                        app(var("-"), var("n")),
                        var("n")
                )));

            test(iff(lit(true), app(var("toFloat"), integer(4)), floating(4.0)));

            //return;

#if false
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
#endif
        }

        private static void test(Expr expression)
        {
            var typeInferrer = new Inferrer();
            var typeEnvironment = typeInferrer.GetDefaultEnvironment(new TypeVarGenerator());

            Console.WriteLine($"INPUT: {expression}");
            var type = typeInferrer.Run(expression, typeEnvironment);
            Console.WriteLine($"OUTPUT: {type}");
            Console.WriteLine();
        }
    }
}
