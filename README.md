HPC-Shelf-MapReduce is a MapReduce application for HPC Storm. The objective is demonstrating the specification of parallel computing systems by using SAFeSWL, as well as its execution model. This MapReduce application is a set components, which can be opened on the Luna Eclipse.

To open:

git
   * mkdir -p ~/workspace/gitsource
   * cd ~/workspace/gitsource
   * git clone https://github.com/UFC-MDCC-HPC/Hash-Programming-Environment
   * git clone https://github.com/UFC-MDCC-HPC/HPC-Shelf-MapReduce
   * cd HPC-Shelf-MapReduce
   * sh config-components.sh

Open Luna
  * import HCLCompiler from Hash-Programming-Environment
  * Import HPE_FrontEnd from Hash-Programming-Environment
  * Menu Luna: 
              * Run->Run Configurations
              * Eclipse Application
              * new launch configuration
              * Field Name = HPC-Shelf-MapReduce
              * Field Location = ~/workspace/gitsource/HPC-Shelf-MapReduce
