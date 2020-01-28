![USGS](https://github.com/tgross-usgs/RunoffModelingServices/blob/staging/USGS_ID_black200.png)


# Runoff Modeling Services

StreamStats supporting runoff modeling REST web services:

<ul>
    <li>Rational Method (Kuichling, 1889)</li>
    <li>TR55 - based on the NRCS runoff curve number method (Natural Resource Conservation Service, 1986)</li>
</ul>

### Prerequisites

<a href="https://www.visualstudio.com/">Visual Studio 2017</a>

<a href="https://www.microsoft.com/net/core#windowscmd">.NET Core</a>

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

### Installing

https://help.github.com/articles/cloning-a-repository/

Open the solution file (.sln) using preferred IDE.

## Building and testing

No testing files are currently available for this repository

## Deployment on IIS

see <a href="https://docs.microsoft.com/en-us/aspnet/core/publishing/iis?tabs=aspnetcore2x">link</a> for detailed instructions for deploying to windows server.

<ul>
  <li>Download and install <a href="https://www.microsoft.com/net/download/core#/runtime">windows server hosting bundle</a> on the server.</li>
  <li>Create new application pool specifying the .netCLR version property to "No Managed Code".</li>
</ul>

## Deployment on Linux

see <a href="https://docs.microsoft.com/en-us/aspnet/core/publishing/apache-proxy">link for detailed instructions for deploying to linux server

## Built With

<a href="https://github.com/dotnet/core">Dotnetcore 2.0</a> - ASP.Net core Framework

## Contributing

Please read [CONTRIBUTING.md](CONTRIBUTING.md) for details on the process for submitting pull requests to us. Please read [CODE_OF_CONDUCT.md](CODE_OF_CONDUCT.md) for details on adhering by the [USGS Code of Scientific Conduct](https://www2.usgs.gov/fsp/fsp_code_of_scientific_conduct.asp).

## Versioning

We use [SemVer](http://semver.org/) for versioning. For the versions available, see the [tags on this repository](../../tags). 

Advance the version when adding features, fixing bugs or making minor enhancement. Follow semver principles. To add tag in git, type git tag v{major}.{minor}.{patch}. Example: git tag v2.0.5

To push tags to remote origin: `git push origin --tags`

*Note that your alias for the remote origin may differ.

## Authors

* <a href="https://www.usgs.gov/staff-profiles/tara-a-gross"><b>Tara Gross</b></a> - *Lead Developer* -  [USGS Colorado Water Science Center](https://www.usgs.gov/centers/co-water)
* <a href="https://www.usgs.gov/staff-profiles/jeremy-k-newson"><b>Jeremy Newson</b></a> - *Developer* - [USGS Web Informatics & Mapping](https://www.usgs.gov/water-resources/wim/)
* <a href="https://www.usgs.gov/staff-profiles/michael-s-kohn"><b>Michael Kohn</b></a> - *Civil Engineer* - [USGS Colorado Water Science Center](https://www.usgs.gov/centers/co-water)

## License

This project is licensed under the Creative Commons CC0 1.0 Universal License - see the [LICENSE.md](LICENSE.md) file for details

## Suggested Citation
In the spirit of open source, please cite any re-use of the source code stored in this repository. Below is the suggested citation:

`Gross, T.A., Newson, J.K., and Kohn, M.S. 2020, Runoff Modeling Services: U.S.Geological Survey software release, https://doi.org/10.5066/P910XSVJ`


## Acknowledgments

* [USGS WIM team](https://wim.usgs.gov)
