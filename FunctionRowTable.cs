using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    internal class FunctionRowTable : BaseViewModel
    {
        private double _x;
        private double _y;
        private double? _f;

        /// <summary>Значение X.</summary>
        public double X { get => _x; set => _x = value; }


        /// <summary>Значение Y.</summary>
        public double Y { get => _y; set => _y = value; }

        /// <summary>Значение Функции для текущих значений <see cref="X"/> и <see cref="Y".</summary>
        public double? F { get => _f; private set => _f = value; }


        private FunctionModel function;

        /// <summary>Задаёт Функцию от двух аргументов.</summary>
        /// <param name="function">Функция от двух аргументов.</param>
        public void SetFunction(FunctionModel function)
        {
            this.function = function ?? throw new ArgumentNullException(nameof(function));
            F = function?.Function(X, Y);
        }

        protected void OnPropertyChanged(string propertyName, object oldValue, object newValue)
        {
            OnPropertyChanged(propertyName, oldValue, newValue);

            // Пересчёт значения Функции если изменилось значение X или Y.
            if (propertyName == nameof(X) || propertyName == nameof(Y))
                F = function?.Function(X, Y);
        }
    }
}
