namespace OOPsReview
{
    public class Employment
    {
        private SupervisoryLevel _Level;
        private string _Title;
        private double _years;

        public string Title
        {
            get { return _Title; }
            set {
                if (string.IsNullOrWhiteSpace(value)) 
                { 
                    throw new ArgumentNullException("Title is required");
                }
                
                _Title = value;
            }
        }
    }
}