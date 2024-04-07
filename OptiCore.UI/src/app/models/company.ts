import ContactDetails from './contactdetails';

interface Company {
  id: number;
  createdOn: string;
  createdBy: string;
  tenantId: number;
  updatedOn: string;
  updatedBy: string;
  name: string;
  registrationNumber: string;
  contactDetails: ContactDetails[];
  companyType: number;
  isActive: boolean;
  childHierarchies: string[];
  parentHierarchy: string;
  commissions: string[];
}

export default Company;
