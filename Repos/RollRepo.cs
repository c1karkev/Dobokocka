using Dobokocka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dobokocka.Repos
{
    public class RollRepo
    {
        private readonly List<Roll> _rolls = new();

        public IReadOnlyList<Roll> GetAll()
        {
            return _rolls.ToList();
        }

        public void Add(Roll roll)
        {
            _rolls.Add(roll);
        }

    }
}
