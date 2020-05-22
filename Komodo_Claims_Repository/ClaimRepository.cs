using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Claims_Repository
{
    public class ClaimRepo
    {
        Queue<Claims> _queueOfClaim = new Queue<Claims>();
        bool _isValid;

        public void AddClaimToQueue(Claims claim)
        {
            _queueOfClaim.Enqueue(claim);
        }

        public Queue<Claims> ShowClaimList()
        {
            return _queueOfClaim;
        }

        public Queue<Claims> RemoveClaim()
        {

            _queueOfClaim.Dequeue();
            return _queueOfClaim;
        }

        public Queue<Claims> NextClaim()
        {
            return _queueOfClaim;
        }
        public bool ValidDate(Claims claim)
        {
            TimeSpan TimeBetweenDates = Convert.ToDateTime(claim.DateOfClaim) - Convert.ToDateTime(claim.DateOfIncident);

            bool IsVaild;
            if (TimeBetweenDates.Days <= 30)
            {
                _isValid = true;
            }
            else
            {
                _isValid = false;
            }

            IsVaild = _isValid;
            return IsVaild;
        }
    }
}
