import ContactDetails from './contactdetails';

export interface Companies {
    name: string;
    registrationNumber: string;
    contactDetails: ContactDetails[];
    companyType: number;
    isActive: boolean;
  }