using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Building.AlgorithmW
{
    public abstract record WType;

    public record VariableType(TypeVar TypeVar) : WType
    {
        public override string ToString() => TypeVar.ToString();
    }

    public abstract record PrimitiveType : WType;

    public record IntegerType : PrimitiveType
    {
        public override string ToString() => "Int";
    }

    public record FloatType : PrimitiveType
    {
        public override string ToString() => "Float";
    }

    public record BoolType : PrimitiveType
    {
        public override string ToString() => "Bool";
    }

    public record StringType : PrimitiveType
    {
        public override string ToString() => "String";
    }

    public record FunctionType(WType TypeIn, WType TypeOut) : WType
    {
        public override string ToString() => $"({TypeIn} → {TypeOut})";
    }
}
