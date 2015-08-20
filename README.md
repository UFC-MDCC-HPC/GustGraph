**HPC-Shelf-MapReduce** is a MapReduce application for **HPC Storm**. This application is a set of components, which can be opened on the **Eclipse Luna**.

Instructions
------------

git:
----

* mkdir -p ~/workspace/gitsource
* cd ~/workspace/gitsource
* git clone https://github.com/UFC-MDCC-HPC/Hash-Programming-Environment
* git clone https://github.com/UFC-MDCC-HPC/HPC-Shelf-MapReduce
* cd ~/workspace/gitsource/HPC-Shelf-MapReduce
* **sh config-components.sh**

Open on Eclipse Luna:
----------

* import **HCLCompiler** from **Hash-Programming-Environment**
* Import **HPE_FrontEnd** from **Hash-Programming-Environment**
* Menu Luna: 
  * Run->Run Configurations
  * Eclipse Application
  * new launch configuration
  * Field Name = HPC-Shelf-MapReduce
  * Field Location = workspace/gitsource/HPC-Shelf-MapReduce (**don't use ~/**)
  * Run
  * File**->**Import**->**General**->**Existing Projects into Workspace**->**Browse HPC-Shelf-MapReduce directory**->**Finish
  * Open Perspective **Hash Programming Environment**
  * Open *.hpe components


**Common libs**: the components require 3 dlls (DGAC, MPI and MySql). This was included in the directory **HPC-Shelf-MapReduce/HPC-Shelf-MapReduce/lib**

