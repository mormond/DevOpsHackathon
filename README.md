# DevOpsHackathon

During the DevOps hackathon, we challenged ourselves to come up with a feature flags implementation for an ASP.NET MVC web site architecture.

The goals were to:
<ol>
<li>Enable feature flags to be enabled / disabled from config</li>
<li>Implement an extensible strategy set (including boolean, time-bounded, random, user-defined)</li>
<li>Minimise code changes required to add a feature flag</li>
<li>Create a foundation on which to implement A/B testing and support Hypothesis-Driven Development
</ol>

Features are implemented by swapping out controllers. That is, any change in behaviour is a result of invoking a different controller class. The controller factory checks if there is a valid feature flag enabled for the current request. If there is, it rewrites the controller name to invoke the alternative behaviour.
