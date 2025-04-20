#!/bin/bash

echo -e "REPOSITORY\tTAG\tIMAGE ID\tACTUAL TAG"

for repo in $(docker images --format "{{.Repository}}" | sort | uniq); do
    image_ids=$(docker images $repo --format "{{.ID}}\t{{.Tag}}" | sort | uniq)
    latest_id=$(echo "$image_ids" | grep 'latest' | cut -f1)

    while IFS=$'\t' read -r id tag; do
        if [ "$id" == "$latest_id" ] && [ "$tag" != "latest" ]; then
            echo -e "$repo\tlatest\t$id\t(tag=$tag)"
        fi
    done <<< "$image_ids"
done
