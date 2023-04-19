using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    internal class FunctionModel
    {
        /// <summary>Имя Функции
        public string Name { get; }

        /// <summary>Делегат Функции
        public Func<double, double, double> Function { get; }

        /// <summary>Коэффициент A
        public double A { get; set; }

        /// <summary>Коэффициент B
        public double B { get; set; }

        /// <summary>Коэффициент C
        public double C { get; set; }

        public IReadOnlyList<double> Arguments { get; }

        /// <summary>Создаёт экземпляр <see cref="FunctionModel"
        /// <param name="name">Имя Функции
        /// <param name="function">Делегат Функции.</param>
        public FunctionModel(string name, IEnumerable<double> arguments, Func<double, double, double, double, double, double> function)
        {
            Name = name;
            Arguments = arguments.ToList().AsReadOnly();
            this.function = function ?? throw new ArgumentNullException(nameof(function));
            Function = Calculate;
        }
        private readonly Func<double, double, double, double, double, double> function;
        private double Calculate(double x, double y)
            => function(A, B, C, x, y);
    }
}
