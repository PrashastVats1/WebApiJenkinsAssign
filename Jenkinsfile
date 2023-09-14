pipeline {
    agent any
    
    stages {
        stage('Checkout') {
            steps {
                // Use Git to check out the source code
                checkout scm
            }
        }
        
        stage('Build') {
            steps {
                // Build the .NET Core Web API project
                sh 'dotnet build'
            }
        }
        
        stage('Test') {
            steps {
                // Run unit tests for the project
                sh 'dotnet test'
            }
        }
        
        stage('Publish') {
            steps {
                // Publish the Web API project
                sh 'dotnet publish -c Release -o ./publish'
            }
        }
    }
    
    post {
        failure {
            // Send notifications if any stage fails (e.g., via email or Slack)
            echo "Pipeline failed! Send notifications here."
        }
    }
}
