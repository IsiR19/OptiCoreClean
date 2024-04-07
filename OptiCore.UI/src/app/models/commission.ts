import Company from './company';

interface Commission {
  id: number;
  createdOn: string;
  createdBy: string;
  tenantId: number;
  updatedOn: string;
  updatedBy: string;
  companyId: number;
  amount: number;
  level: number;
  company: Company;
}

export default Commission;
