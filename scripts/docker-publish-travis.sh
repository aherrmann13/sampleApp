docker login -u $DOCKER_USERNAME -p $DOCKER_PASSWORD

docker build -t api ./src/api/ --no-cache

docker tag api $DOCKER_USERNAME/sampleapp-api

docker push $DOCKER_USERNAME/sampleapp-api