using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsurancePolicyManagementApi.Data;
using InsurancePolicyManagementApi.DTOs;
using InsurancePolicyManagementApi.Models;
using Microsoft.EntityFrameworkCore;

namespace InsurancePolicyManagementApi.Services
{
    public class PolicyService
    {
        private readonly ApplicationDbContext _context;

        public PolicyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<PolicyDto>> GetAllPoliciesAsync()
        {
            return await _context.Policies
                .Select(p => new PolicyDto
                {
                    Id = p.Id,
                    PolicyNumber = p.PolicyNumber,
                    PolicyHolderName = p.PolicyHolderName,
                    CoverageAmount = p.CoverageAmount,
                    StartDate = p.StartDate
                }).ToListAsync();
        }

        public async Task<PolicyDto> GetPolicyByIdAsync(int id)
        {
            var policy = await _context.Policies.FindAsync(id);
            if (policy == null) return null;

            return new PolicyDto
            {
                Id = policy.Id,
                PolicyNumber = policy.PolicyNumber,
                PolicyHolderName = policy.PolicyHolderName,
                CoverageAmount = policy.CoverageAmount,
                StartDate = policy.StartDate
            };
        }

        public async Task<PolicyDto> AddPolicyAsync(PolicyDto policyDto)
        {
            var policy = new Policy
            {
                PolicyNumber = policyDto.PolicyNumber,
                PolicyHolderName = policyDto.PolicyHolderName,
                CoverageAmount = policyDto.CoverageAmount,
                StartDate = policyDto.StartDate
            };

            _context.Policies.Add(policy);
            await _context.SaveChangesAsync();

            policyDto.Id = policy.Id;
            return policyDto;
        }

        public async Task<bool> UpdatePolicyAsync(int id, PolicyDto policyDto)
        {
            var policy = await _context.Policies.FindAsync(id);
            if (policy == null) return false;

            policy.PolicyNumber = policyDto.PolicyNumber;
            policy.PolicyHolderName = policyDto.PolicyHolderName;
            policy.CoverageAmount = policyDto.CoverageAmount;
            policy.StartDate = policyDto.StartDate;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePolicyAsync(int id)
        {
            var policy = await _context.Policies.FindAsync(id);
            if (policy == null) return false;

            _context.Policies.Remove(policy);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}