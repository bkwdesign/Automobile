using System;
using System.Collections.Generic;
using System.Linq;
using bkw.auto.interfaces;

namespace bkw.auto.biz
{
    abstract public class BaseOptionModel<T>  where T : IVehicleOption
    {
        #region private/protected
        protected List<T> _availableOpts = new List<T>();
        protected List<T> _selectedOpts = new List<T>();
        protected string[] _requirements = new string[] { };
        #endregion
        public string[] Requirements { get => _requirements; }

        public void LoadOptions(IEnumerable<IVehicleOption> opts)
        {
            opts.ToList().ForEach(option => _availableOpts.Add((T)option));
        }

        public override string ToString()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            var reqlist = _requirements.ToList();
            var firstReq = _requirements.First();

            reqlist.ToList().ForEach(req =>
            {

                if (req!=firstReq) sb.Append(", ");

                var opts = _availableOpts.Where(o => o.Name == req);

                if (opts.Count() == 1)
                {
                    //if there's only a single option of this type of requirement
                    //print out the whole .ToString of that VehicleOption
                    sb.Append($"{opts.First().Brand} {opts.First().Name} package: {opts.First().Description}");

                }
                else if (opts.Count() > 1)
                {
                    //if there's multiple options for this requirement
                    //loop through and list the description property of each
                    sb.Append($"{opts.Count()} {req} options [");

                    var oplist = opts.ToList();

                    for(int i = 0; i < oplist.Count(); i++)
                    {
                        var o = oplist[i];
                        if (i > 0 && i <= oplist.Count - 1) sb.Append(", ");
                        sb.Append(o.Description);
                    }
                    sb.Append("]");
                }             
            });

            return sb.ToString();
        }
    }
}