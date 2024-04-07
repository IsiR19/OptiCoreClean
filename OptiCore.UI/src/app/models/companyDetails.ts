import ContactDetails from './contactdetails';
import ChildHierarchy from './company';
import ParentHierarchy from './company';
import Commission from './commission';

interface CompanyDetails {
  name: string;
  registrationNumber: string;
  contactDetails: ContactDetails[];
  companyType: number;
  isActive: boolean;
  childHierarchies: ChildHierarchy[];
  parentHierarchy: ParentHierarchy;
  commissions: Commission[];
}

export default CompanyDetails;