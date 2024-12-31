using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using InsurancePolicyManagementApi.Models;
using InsurancePolicyManagementApi.Services;

namespace InsurancePolicyManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliciesController : ControllerBase
    {
        private readonly PolicyService _policyService;

        public PoliciesController(PolicyService policyService)
        {
            _policyService = policyService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Policy>>> GetPolicies()
        {
            var policies = await _policyService.GetAllPoliciesAsync();
            return Ok(policies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Policy>> GetPolicy(int id)
        {
            var policy = await _policyService.GetPolicyByIdAsync(id);
            if (policy == null)
            {
                return NotFound();
            }
            return Ok(policy);
        }

        [HttpPost]
        public async Task<ActionResult<Policy>> CreatePolicy(Policy policy)
        {
            var createdPolicy = await _policyService.AddPolicyAsync(policy);
            return CreatedAtAction(nameof(GetPolicy), new { id = createdPolicy.Id }, createdPolicy);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePolicy(int id, Policy policy)
        {
            if (id != policy.Id)
            {
                return BadRequest();
            }

            await _policyService.UpdatePolicyAsync(policy);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePolicy(int id)
        {
            var policy = await _policyService.GetPolicyByIdAsync(id);
            if (policy == null)
            {
                return NotFound();
            }

            await _policyService.DeletePolicyAsync(id);
            return NoContent();
        }
    }
}